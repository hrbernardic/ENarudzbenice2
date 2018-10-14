using System.Threading.Tasks;
using ENarudzbenice2.Application.Features.Auth.Commands;
using ENarudzbenice2.Application.Features.Auth.Models;
using ENarudzbenice2.Application.Features.Identity.Requests;
using ENarudzbenice2.Domain.Entities.App;
using ENarudzbenice2.Web.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ENarudzbenice2.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;

        public AuthController(UserManager<User> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        // POST api/Auth/CreateUser
        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser(UserCreate.Request request)
        {
            return Ok(await Mediator.Send(request));
        }

        // POST api/Auth/Login
        [HttpPost("Login")]
        //[ProducesResponseType(typeof(LoginDto), (int)HttpStatusCode.OK)]
        public async Task<LoginDto> Login(LoginCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}
