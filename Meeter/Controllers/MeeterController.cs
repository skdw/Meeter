using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Meeter.Models;

namespace Meeter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeeterController : ControllerBase
    {
        private readonly MeeterDbContext context;

        public MeeterController(MeeterDbContext ctx)
        {
            context = ctx;
        }

        // GET api/meeter/users
        [HttpGet("users")]
        public IEnumerable<User> GetUsers()
        {
            return context.Users.AsEnumerable();
        }

        // GET api/meeter/events
        [HttpGet("events")]
        public IEnumerable<Event> GetEvents()
        {
            return context.Events.OrderBy(e => e.DateTime).AsEnumerable();
        }

        // POST api/meeter/events
        [HttpPost]
        public async Task<IActionResult> PostEvent([FromBody] Event @event)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (@event.GroupId == 0)
                return BadRequest(ModelState);

            context.Events.Add(@event);

            await context.SaveChangesAsync();

            return CreatedAtAction("GetEvents", new { id = @event.Id }, @event);
        }




        // GET api/meeter
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/meeter/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/meeter
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/meeter/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/meeter/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
