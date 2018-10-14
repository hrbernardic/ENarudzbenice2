using ENarudzbenice2.Domain.Entities.App;
using MediatR;

namespace ENarudzbenice2.Application.Features.Auth.Commands
{
    public class UserCreateCommand : IRequest<User>
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Naziv { get; set; }
        public string Prezime { get; set; }
        
    }
}
