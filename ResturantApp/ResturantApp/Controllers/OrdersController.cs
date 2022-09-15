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
    public class OrdersController : ControllerBase
    {
        // GET: api/<OrdersController>
        private restaurantdbContext _restaurantdbContext;

        public OrdersController(restaurantdbContext restaurantdbContext)
        {
            _restaurantdbContext = restaurantdbContext;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var x = _restaurantdbContext.MenuCustomers.ToList();
            if (x == null)
            {
                return Ok(" 404, Not found");
            }
            return Ok(x);
        }

        // GET api/<OrdersController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var x = _restaurantdbContext.MenuCustomers.Find(id);
            if (x == null)
            {
                return Ok(" 404, Not found");
            }
            return Ok(x);
        }

        private bool isAvailable(int Id)
        {
            var x = _restaurantdbContext.RestaurantMenus.Find(Id);
            if (x != null)
            {
                if (x.Quantity>0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
            
        }

        // POST api/<OrdersController>
        [HttpPost]
        public void Post([FromBody] OrderView orderView)
        {
                var x = _restaurantdbContext.RestaurantMenus.Find(orderView.Mid);
                var y = _restaurantdbContext.Customers.Find(orderView.Cid);

            if (x!= null && y!= null && isAvailable(orderView.Mid))
            {
                var order = _restaurantdbContext.MenuCustomers
                .Add(new MenuCustomer
                {
                    Mid = orderView.Mid,
                    Cid = orderView.Cid,
                    CraetedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                }
                );
                _restaurantdbContext.SaveChanges();
            }
        }

        // PUT api/<OrdersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] OrderView orderView)
        {
            var z = _restaurantdbContext.MenuCustomers.Find(id);
            var x = _restaurantdbContext.RestaurantMenus.Find(orderView.Mid);
            var y = _restaurantdbContext.Customers.Find(orderView.Cid);
            
            if (z!= null && x != null && y != null && isAvailable(orderView.Mid))
            {
                z.Mid = orderView.Mid;
                z.Cid = orderView.Cid;
                x.UpdatedDate = DateTime.UtcNow;
                _restaurantdbContext.SaveChanges();
            }
        }

        // DELETE api/<OrdersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var x = _restaurantdbContext.MenuCustomers.Find(id);
            if (x != null)
            {
                _restaurantdbContext.MenuCustomers.Remove(x);
                _restaurantdbContext.SaveChanges();
            }
        }
    }
}
