using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ENarudzbenice2.Application.Features.Djelatnosti.Requests;
using ENarudzbenice2.Domain.Entities;
using ENarudzbenice2.Web.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace ENarudzbenice2.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DjelatnostiController : BaseController
    {
        // GET api/djelatnosti
        [HttpGet]
        public Task<List<Djelatnost>> GetAll()
        {
            return Mediator.Send(new DjelatnostGetAll.Request());
        }

        // GET api/djelatnosti/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(await Mediator.Send(new DjelatnostGet.Request { Id = id } ));
        }

        // POST api/djelatnosti
        [HttpPost]
        public async Task<IActionResult> Create(DjelatnostCreate.Request request)
        {
            return Ok(await Mediator.Send(request));
        }

        // PUT api/djelatnosti/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, DjelatnostUpdate.Request request)
        {
            if (request is null || request.Id != id)
            {
                return BadRequest();
            }

            return Ok(await Mediator.Send(request));
        }

        // DELETE api/djelatnosti/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await Mediator.Send(new DjelatnostDelete.Request { Id = id } ));
        }
    }
}