using Microsoft.AspNetCore.Mvc;
using ResturantApp.Models;
using ResturantApp.ModelViews;
using System;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ResturantApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private restaurantdbContext _restaurantdbContext;

        public MenuController(restaurantdbContext restaurantdbContext)
        {
            _restaurantdbContext = restaurantdbContext;
        }
        // GET: api/<MenuController>
        [HttpGet]
        public IActionResult Get()
        {
            var x = _restaurantdbContext.RestaurantMenus.ToList();
            if (x == null)
            {
                return Ok(" 404, Not found");
            }
            return Ok(x);
        }

        // GET api/<MenuController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var x = _restaurantdbContext.RestaurantMenus.Find(id);
            if (x == null)
            {
                return Ok(" 404, Not found");
            }
            return Ok(x);
        }

        // POST api/<MenuController>
        [HttpPost]
        public void Post([FromBody] MenuView menuView)
        {
            var x = _restaurantdbContext.Restaurants.Find(menuView.Rid);
            if (x!=null)
            {
                var menu = _restaurantdbContext.RestaurantMenus
               .Add(new RestaurantMenu
               {
                   MealName = menuView.MealName,
                   PriceInNis = menuView.PriceInNis,
                   Rid = menuView.Rid,
                   Quantity = menuView.Quantity,
                   CraetedDate = DateTime.UtcNow,
                   UpdatedDate = DateTime.UtcNow,
                   PriceInUsd = menuView.PriceInNis / 3.50
               }
               );
                _restaurantdbContext.SaveChanges();
            }
        }

        // PUT api/<MenuController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] MenuView menuView)
        {
            var x = _restaurantdbContext.RestaurantMenus.Find(id);
            var y = _restaurantdbContext.Restaurants.Find(menuView.Rid);
            if (x != null && y != null)
            {
                x.MealName = menuView.MealName;
                x.PriceInNis = menuView.PriceInNis;
                x.Rid = menuView.Rid;
                x.Quantity = menuView.Quantity;
                x.PriceInUsd = menuView.PriceInNis / 3.50;
                x.UpdatedDate = DateTime.UtcNow;
                _restaurantdbContext.SaveChanges();
            }
            
        }

        // DELETE api/<MenuController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var x = _restaurantdbContext.RestaurantMenus.Find(id);
            if (x != null)
            {
                _restaurantdbContext.RestaurantMenus.Remove(x);
                _restaurantdbContext.SaveChanges();
            }
        }
    }
}
