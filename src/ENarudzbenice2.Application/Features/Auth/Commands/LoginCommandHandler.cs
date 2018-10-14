using System.Threading;
using System.Threading.Tasks;
using ENarudzbenice2.Application.Exceptions;
using ENarudzbenice2.Application.Features.Auth.Models;
using ENarudzbenice2.Domain.Entities.App;
using ENarudzbenice2.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace ENarudzbenice2.Application.Features.Auth.Commands
{
    public class LoginCommandHandler: IRequestHandler<LoginCommand, LoginDto>
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;

        public LoginCommandHandler(UserManager<User> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<LoginDto> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.Username);
            if (!await _userManager.CheckPasswordAsync(user, request.Password))
                throw new CheckPasswordException();

            var token = new JwtTokenBuilder()
                .AddSecurityKey(JwtSecurityKey.Create(_configuration["Jwt:SecretKey"]))
                //.AddClaim("Fullname", user.PrikazIme)
                .AddSubject(user.Email)
                .AddIssuer(_configuration["Jwt:Issuer"])
                .AddAudience(_configuration["Jwt:Audience"])
                .AddClaim("Id", user.Id.ToString())
                .Build();

            return new LoginDto
            {
                Username = user.UserName,
                Token = token.Value
            };
        }
    }
    
}
