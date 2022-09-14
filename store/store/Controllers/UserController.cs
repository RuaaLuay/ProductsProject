using Microsoft.AspNetCore.Mvc;
using store.Model;
using store.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // GET: api/<Ruaa2Controller>

        private storeContext _storeContext;

        public UserController(storeContext storeContext)
        {
            _storeContext = storeContext;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_storeContext.Users.ToList());
        }

        // GET api/<Ruaa2Controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<Ruaa2Controller>
        [HttpPost]
        public IActionResult Post([FromBody] UserRegistration userRegistration)
        {
            var user = _storeContext.Users.FirstOrDefault(a => a.Email.Equals(userRegistration.Email.ToLower()));
            if (user!=null)
            {
                return BadRequest("user already exist");
            }
            user = _storeContext.Users.Add(
                new User
                {
                    FirstName = userRegistration.FirstName,
                    LastName = userRegistration.LastName,
                    Email = userRegistration.Email,
                    Password = userRegistration.Password,
                    ConfirmPassword = userRegistration.Password
                }).Entity;
            _storeContext.SaveChanges();
            return Ok();
        }

        // PUT api/<Ruaa2Controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<Ruaa2Controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
