using LINQtoCSV;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using store.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RuaaController : ControllerBase
    {
        private storeContext _storeContext;

        public RuaaController(storeContext storeContext)
        {
            _storeContext = storeContext;
        }

        // GET: api/<RuaaController>
        [HttpGet]
        public IEnumerable<Item> GetItems()
        {
            var x = _storeContext.Items.ToList();
            return x; 
        }

        [HttpPost]
        public IEnumerable<String> create_csvFile()
        {
            WriteCsvFile();
            yield return "CSV File Created";
        }

       
        private void WriteCsvFile()
        {
            var itemList = _storeContext.Items.ToList();

            var csvFileDescription = new CsvFileDescription
            {
                FirstLineHasColumnNames = true,
                SeparatorChar = ','
            };

            var csvContext = new CsvContext();
            csvContext.Write(itemList, "items.csv", csvFileDescription);
        }





        // GET api/<RuaaController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<RuaaController>
        
        

        // PUT api/<RuaaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RuaaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
