using System.Collections.Generic;
using System.Threading.Tasks;
using ENarudzbenice2.Application.Features.Adrese.Requests;
using ENarudzbenice2.Domain.Entities;
using ENarudzbenice2.Web.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace ENarudzbenice2.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdreseController : BaseController
    {
        // GET api/djelatnosti
        [HttpGet]
        public Task<List<Adresa>> GetAll()
        {
            return Mediator.Send(new AdreseGetAll.Request());
        }
    }
}
