using System;
using System.IO;
using System.Net.WebSockets;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ENarudzbenice2.Application.Features.Djelatnosti.Requests;
using ENarudzbenice2.Application.Features.Djelatnosti.Validations;
using ENarudzbenice2.Application.Infrastructure;
using ENarudzbenice2.Identity;
using ENarudzbenice2.Persistence;
using ENarudzbenice2.Web.Filters;
using FluentValidation.AspNetCore;
using MediatR;
using MediatR.Pipeline;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.AspNetCore.WebSockets;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using NSwag;
using NSwag.AspNetCore;
using NSwag.CodeGeneration.TypeScript;

namespace ENarudzbenice2.Web
{
    public class Startup
    {
        private readonly IHostingEnvironment _env;

        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            _env = env;
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add Swagger
            services.AddSwagger();

            // Add MediatR
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPreProcessorBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            services.AddMediatR(typeof(DjelatnostGetAll.RequestHandler).GetTypeInfo().Assembly);

            // Add DbContext
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("ENarudzbenice2Dev")));

            //Identity
            services.AddIdentityServices<ApplicationDbContext>();

            //Authentication
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration["Jwt:Issuer"],
                        ValidAudience = Configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:SecretKey"]))
                    };
                });

            //CORS
            services.AddCors();

            services.AddMvc(options => options.Filters.Add(typeof(CustomExceptionFilterAttribute)))
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<DjelatnostCreateValidator>());

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            
            //GenerateSwaggerTypescriptClient();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebSockets();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseSwaggerUi3WithApiExplorer(settings =>
            {
                settings.SwaggerUiRoute = "/docs";
                settings.SwaggerRoute = "/docs/api-specification.json";
                settings.PostProcess = document =>
                {
                    document.Info.Version = "v0.1";
                    document.Info.Title = "ENarudzbenice2 Api";
                };
            });

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            if (env.IsDevelopment())
            {
                app.Use(async (context, next) =>
                {
                    if (context.Request.Path.ToString().EndsWith("/websocket"))
                    {
                        if (context.WebSockets.IsWebSocketRequest)
                        {

                            var webSocket = await context.WebSockets.AcceptWebSocketAsync();
                            await Echo(context, webSocket);
                        }
                        else
                        {
                            context.Response.StatusCode = 400;
                        }
                    }
                    else
                    {
                        await next();
                    }

                });
            }

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501
                
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    //spa.UseProxyToSpaDevelopmentServer("http://localhost:4200");
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }

        private void GenerateSwaggerTypescriptClient()
        {
            if (!_env.IsDevelopment())
            {
                return;
            }

            var document = SwaggerDocument.FromFileAsync($"{Environment.CurrentDirectory}/wwwroot/docs/api-specification.json").Result;

            var settings = new SwaggerToTypeScriptClientGeneratorSettings
            {
                ClassName = "{controller}Client",
                Template = TypeScriptTemplate.Angular,
                RxJsVersion = (decimal) 6.3,
                InjectionTokenType = InjectionTokenType.InjectionToken,
                HttpClass = HttpClass.HttpClient
            };

            var generator = new SwaggerToTypeScriptClientGenerator(document, settings);
            var code = generator.GenerateFile();

            File.WriteAllText($"{Environment.CurrentDirectory}/ClientApp/src/app/shared/enarudzbenice2-api.ts", code);
        }

        private async Task Echo(HttpContext context, WebSocket webSocket)
        {
            var buffer = new byte[1024 * 4];
            WebSocketReceiveResult wsresult = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer),
                CancellationToken.None);
            while (!wsresult.CloseStatus.HasValue)
            {
                await webSocket.SendAsync(new ArraySegment<byte>(buffer, 0, wsresult.Count), wsresult.MessageType,
                    wsresult.EndOfMessage, CancellationToken.None);
                wsresult = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
            }
            await webSocket.CloseAsync(wsresult.CloseStatus.Value, wsresult.CloseStatusDescription,
                CancellationToken.None);
        }
    }
}
