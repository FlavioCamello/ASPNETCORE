using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Value> Get()
        {
            List<Value> v = new List<Value>();
            v.Add(new Value(1, "texto"));
            v.Add(new Value(2, "texto2"));

            return v;
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        //[Produces("application/json")]
        public IActionResult Get(int id)
        {
            return Ok();
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
    public class Value
    {
        public Value(int id, string text)
        {
            Id = id;
            Text = text;
        }

        public int Id { get; set; }

        [MinLength(3)]
        public string Text { get; set; }
    }
}
