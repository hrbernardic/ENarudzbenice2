using ENarudzbenice2.Application.Features.Auth.Models;
using MediatR;

namespace ENarudzbenice2.Application.Features.Auth.Commands
{
    
    public class UserLoginCommand : IRequest<LoginDto>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
    
}
