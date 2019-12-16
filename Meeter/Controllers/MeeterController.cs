using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Meeter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeeterController : ControllerBase
    {
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
