using ENarudzbenice2.Domain.Entities.App;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ENarudzbenice2.Identity
{
    public static class IdentityServiceExtensions
    {
        public static IdentityBuilder AddIdentityServices<TContext>(this IServiceCollection services) where TContext : DbContext
        {
            var builder = services.AddIdentityCore<User>(opt =>
                {
                    opt.Password.RequireDigit = false;
                    opt.Password.RequireUppercase = false;
                    opt.Password.RequireNonAlphanumeric = false;
                    opt.Password.RequireDigit = false;
                    opt.Password.RequiredLength = 4;
                })
                .AddErrorDescriber<LocalizedIdentityErrorDescriber>();

            builder = new IdentityBuilder(builder.UserType, typeof(Role), builder.Services);
            builder.AddRoleValidator<RoleValidator<Role>>();
            builder.AddRoleManager<RoleManager<Role>>();
            builder.AddSignInManager<SignInManager<User>>();

            builder.AddEntityFrameworkStores<TContext>();

            return builder;
        }
    }
}
