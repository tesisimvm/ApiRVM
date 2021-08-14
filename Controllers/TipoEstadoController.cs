using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiRVM2019.Contexts;
using ApiRVM2019.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiRVM2019.Controllers
{
    [EnableCors("All")]
    [Route("[controller]")]
    [ApiController]
    public class TipoEstadoController : ControllerBase
    {
        private readonly AppDbContext context;

        public TipoEstadoController(AppDbContext context)
        {
            this.context = context;
        }
        // GET: api/<TpoEstadoController>
        [HttpGet]
        public IEnumerable<TipoEstado> Get()
        {
            return context.TipoEstado.ToList();
        }

        // GET api/<TpoEstadoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
           var tipoestado=context.TipoEstado.FirstOrDefault(r=> r.IDTipoEstado==id);
            //return tipoestado;
        }

        // POST api/<TpoEstadoController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TpoEstadoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TpoEstadoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
