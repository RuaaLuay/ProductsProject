using CsvHelper;
using LINQtoCSV;
using Microsoft.AspNetCore.Mvc;
using ResturantApp.Models;
using System.Linq;




namespace ResturantApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CsvController : ControllerBase
    {
        private restaurantdbContext _restaurantdbContext;

        public CsvController(restaurantdbContext restaurantdbContext)
        {
            _restaurantdbContext = restaurantdbContext;
        }
        [HttpGet]
        public IActionResult Get()
        {
            WriteCsvFile();
            return Ok();
        }
        private void WriteCsvFile()
        {
            var itemList = _restaurantdbContext.CsvViews.ToList();

            var csvFileDescription = new CsvFileDescription
            {
                FirstLineHasColumnNames = true,
                SeparatorChar = ','
            };

            var csvContext = new LINQtoCSV.CsvContext();
            csvContext.Write(itemList, "D:\\Resturant.csv", csvFileDescription);
        }


    }
}
