using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ENarudzbenice2.Domain.Entities.App;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace ENarudzbenice2.Application.Features.Identity.Requests
{
    public abstract class UserCreate
    {
        public class Request : IRequest<User>
        {
            public string Email { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
        }

        public class RequestHandler : IRequestHandler<Request, User>
        {
            private readonly UserManager<User> _userManager;

            public RequestHandler(UserManager<User> userManager)
            {
                _userManager = userManager;
            }

            public async Task<User> Handle(Request request, CancellationToken cancellationToken)
            {
                var user = new User
                {
                    Email = request.Email,
                    UserName = request.Username
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
}
