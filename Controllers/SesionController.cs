using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiRVM2019.Contexts;
using ApiRVM2019.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiRVM2019.Controllers
{
    [EnableCors("All")]
    [Route("[controller]")]
    [ApiController]
    public class SesionController : ControllerBase
    {
        private readonly AppDbContext context;

        public SesionController(AppDbContext context)
        {
            this.context = context;
        }
        // GET: api/<SesionController>
        [HttpGet]
        public IEnumerable<Sesion> Get()
        {
            return context.Sesion.ToList();
        }

        // GET api/<SesionController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SesionController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SesionController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SesionController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
