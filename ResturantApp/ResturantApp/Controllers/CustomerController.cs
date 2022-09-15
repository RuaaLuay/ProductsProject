using Microsoft.AspNetCore.Mvc;
using ResturantApp.Extensions;
using ResturantApp.Models;
using ResturantApp.ModelViews;
using System;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ResturantApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private restaurantdbContext _restaurantdbContext;

        public CustomerController(restaurantdbContext restaurantdbContext)
        {
            _restaurantdbContext = restaurantdbContext;
        }
        // GET: api/<CustomerController>
        [HttpGet]
        public IActionResult Get()
        {
            var x = _restaurantdbContext.Customers.ToList();
            if (x == null)
            {
                return Ok(" 404, Not found");
            }
            return Ok(x);
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var x = _restaurantdbContext.Customers.Find(id);
            if (x == null)
            {
                return Ok(" 404, Not found");
            }
            return Ok(x);
        }

        // POST api/<CustomerController>
        [HttpPost]
        public void Post([FromBody] CustomerView customerView)
        {
            
                var customer = _restaurantdbContext.Customers
               .Add(new Customer
               {
                   FirstName = customerView.FirstName.capitalize_first_char(),
                   LastName = customerView.LastName.capitalize_first_char(),
                   CraetedDate = DateTime.UtcNow,
                   UpdatedDate = DateTime.UtcNow,
               }
               );
                _restaurantdbContext.SaveChanges();
            
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] CustomerView customerView)
        {
            var x = _restaurantdbContext.Customers.Find(id);
            if (x != null)
            {
                x.FirstName = customerView.FirstName.capitalize_first_char();
                x.LastName = customerView.LastName.capitalize_first_char();
                x.UpdatedDate = DateTime.UtcNow;
            }
            _restaurantdbContext.SaveChanges();
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var x = _restaurantdbContext.Customers.Find(id);
            if (x != null)
            {
                _restaurantdbContext.Customers.Remove(x);
                _restaurantdbContext.SaveChanges();
            }
        }
    }
}
