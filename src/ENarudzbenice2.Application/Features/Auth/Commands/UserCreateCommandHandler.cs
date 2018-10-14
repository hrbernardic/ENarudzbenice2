using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ENarudzbenice2.Domain.Entities.App;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace ENarudzbenice2.Application.Features.Auth.Commands
{
    public class UserCreateCommandHandler : IRequestHandler<UserCreateCommand, User>
    {
        private readonly UserManager<User> _userManager;

        public UserCreateCommandHandler(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<User> Handle(UserCreateCommand request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                Email = request.Email,
                UserName = request.Username,
                Ime = request.Naziv,
                Prezime = request.Prezime
            };

            var createResult = await _userManager.CreateAsync(user, request.Password);

            if (!createResult.Succeeded)
            {
                throw new Exception(createResult.Errors.FirstOrDefault()?.Description);
            }

            return user;
        }
    }
}
