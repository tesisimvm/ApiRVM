using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiRVM2019.Controllers.FiltrosHistorialController
{
    [Route("[controller]")]
    [ApiController]
    public class BusquedaReclamosController : ControllerBase
    {
        // GET: api/<BusquedaReclamosController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<BusquedaReclamosController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<BusquedaReclamosController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<BusquedaReclamosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BusquedaReclamosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
