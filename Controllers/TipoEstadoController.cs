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
        public IActionResult GetTipoEstados()
        {
            var _tipoestados = from TipoEstado in context.TipoEstado
                                          select new
                                          {
                                              NombreTipoEstado=TipoEstado.nombre
                                          };
            if(_tipoestados==null)
            {
                return NotFound();
            }

            return Ok(_tipoestados);
        }

        // GET api/<TpoEstadoController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoEstado>> GetTipoEstado(int id)
        {
            var tipoestado= await context.TipoEstado.FindAsync(id) ;

            if(tipoestado==null)
            {
                return NotFound();
            }

            return tipoestado;
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
