using System.Collections.Generic;
using System.Threading.Tasks;
using DDFramework;
using ENarudzbenice2.Application.Features.Adrese.Requests;
using ENarudzbenice2.Domain.Entities;
using ENarudzbenice2.Persistence;
using ENarudzbenice2.Web.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace ENarudzbenice2.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdreseController : BaseController
    {
        // POST api/djelatnosti/Query
        [HttpPost("Query")]
        public Task<TableQueryResponse<AdresaBrowse>> Query([FromBody]TableQueryRequest tableQueryRequest)
        {
            return Mediator.Send(new AdreseQuery.Request(tableQueryRequest));
        }

        // GET api/djelatnosti
        [HttpGet("GetAll")]
        public Task<List<Adresa>> GetAll()
        {
            return Mediator.Send(new AdreseGetAll.Request());
        }
    }
}
