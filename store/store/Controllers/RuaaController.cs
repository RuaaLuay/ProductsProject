using LINQtoCSV;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using RestSharp;
using store.Model;
using store.ModelView;
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
        public IActionResult GetItems()
        {
            var baseUrl = "https://mocki.io/v1/";
            var client = new RestClient(baseUrl);
            var Request = new RestRequest("d4867d8b-b5d5-4a48-a4ab-79131b5809b8");
            var res = client.Execute(Request);
            var x = _storeContext.Items.ToList();
            if (res.IsSuccessful)
            {
                var content = res.Content;
                var mappedResult = JsonConvert.DeserializeObject<List<RestRes>>(content);
                var ss = JsonConvert.SerializeObject(mappedResult);
                return Ok(mappedResult);
            }
           // throw new Exception("mappedResult");
            return BadRequest("unvalid Request");
           // return Ok(x); 
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
