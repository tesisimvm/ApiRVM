using ApiRVM2019.Contexts;
using ApiRVM2019.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiRVM2019.Controllers
{
    [EnableCors("All")]
    [Route("[controller]")]
    [ApiController]
    public class EstadoController : ControllerBase
    {
        private readonly AppDbContext context;

        public EstadoController(AppDbContext context)
        {
            this.context = context;
        }
        // GET: api/<EstadoController>
        [HttpGet]
        public IActionResult Get()
        {
            var _estado = from Estado in context.Estado
                          join TipoEstado in context.TipoEstado on Estado.ID_TipoEstado equals TipoEstado.IDTipoEstado
                          select new { 
                                              tipoEstadoNombre=TipoEstado.nombre, 
                                              estadoNombre=Estado.Nombre 
                                            };
            if(_estado==null)
            {
                return NotFound();
            }

            return Ok(_estado);
        }

        // GET api/<EstadoController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Estado>> GetEstado(int id)
        {
            var _estado = await context.Estado.FindAsync(id);

            if (_estado == null)
            {
                return NotFound();
            }

            return _estado;
        }

        // POST api/<EstadoController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<EstadoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EstadoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
