using consultaService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace consultaService.Controllers
{
    public class ConsultasController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<Consulta> Get()
        {
            List<Consulta> c = new List<Consulta>();
            c.Add(new Consulta(1, "22/08/2018", "11:20"));
            c.Add(new Consulta(2, "23/08/2018", "12:30"));
            c.Add(new Consulta(3, "24/08/2018", "10:00"));
            return c;
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}