using DBFirst.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DBFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RuaaController : ControllerBase
    {
        private DBFirstContext _DbFirstContext { get; set; }
        public RuaaController(DBFirstContext DbFirstContext)
        {
            _DbFirstContext = DbFirstContext;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
          //  _DbFirstContext.ignoredFilter = true;   
            var x = _DbFirstContext.Users.ToList();
            return new string[] { "value1", "value2" };
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
