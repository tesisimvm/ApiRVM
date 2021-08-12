using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiRVM2019.Contexts;
using ApiRVM2019.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiRVM2019.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReclamoController : ControllerBase
    {
        private readonly AppDbContext context;

        public ReclamoController(AppDbContext context)
        {
            this.context = context;
        }
        // GET: api/<ReclamoController>
        [HttpGet]
        public IEnumerable<Reclamo> Get()
        {
            return context.Reclamo.ToList();
        }

        // GET api/<ReclamoController>/5
        [HttpGet("{id}")]
        public Reclamo Get(int id)
        {
             var dato = context.Reclamo.FirstOrDefault(r => r.IDReclamo == id);
            return dato;
        }

        // POST api/<ReclamoController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ReclamoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ReclamoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
