using System.Threading.Tasks;
using ENarudzbenice2.Application.Features.Auth.Commands;
using ENarudzbenice2.Application.Features.Auth.Models;
using ENarudzbenice2.Web.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace ENarudzbenice2.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        // POST api/Auth/CreateUser
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateUser(UserCreateCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // POST api/Auth/Login
        [HttpPost("[action]")]
        public async Task<LoginDto> Login(UserLoginCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}
