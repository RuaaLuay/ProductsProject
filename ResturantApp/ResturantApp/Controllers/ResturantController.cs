using Microsoft.AspNetCore.Mvc;
using ResturantApp.Models;
using ResturantApp.ModelViews;
using System;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ResturantApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResturantController : ControllerBase
    {
        private restaurantdbContext _restaurantdbContext;

        public ResturantController(restaurantdbContext restaurantdbContext)
        {
            _restaurantdbContext = restaurantdbContext;
        }
        // GET: api/<ResturantController>
        [HttpGet]
        public IActionResult Get()
        {
            var x = _restaurantdbContext.Restaurants.ToList();
            if (x == null)
            {
                return Ok(" 404, Not found");
            }
            return Ok(x);
        }

        // GET api/<ResturantController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var x = _restaurantdbContext.Restaurants.Find(id);
            if(x == null)
            {
                return Ok(" 404, Not found");
            }
            return Ok(x);
        }

        // POST api/<ResturantController>
        [HttpPost]
        public void Post([FromBody] RestaurantView restaurantView)
        {
            var resturant = _restaurantdbContext.Restaurants
                .Add(new Restaurant
                {
                    Name = restaurantView.Name,
                    PhoneNumber = restaurantView.PhoneNumber,
                    CraetedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow
                }
                ) ;
            _restaurantdbContext.SaveChanges();
        }

        // PUT api/<ResturantController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] RestaurantView restaurantView)
        {
            var x = _restaurantdbContext.Restaurants.Find(id);
            if(x != null)
            {
                x.Name = restaurantView.Name;
                x.PhoneNumber = restaurantView.PhoneNumber;
                x.UpdatedDate = DateTime.UtcNow;  
            }
            _restaurantdbContext.SaveChanges();
        }

        // DELETE api/<ResturantController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var x = _restaurantdbContext.Restaurants.Find(id);
            if (x != null)
            {
                _restaurantdbContext.Restaurants.Remove(x);
                _restaurantdbContext.SaveChanges();
            }
            
        }
    }
}
