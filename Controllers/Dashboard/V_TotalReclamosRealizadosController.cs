using ApiRVM2019.Contexts;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiRVM2019.Entities;
using Microsoft.EntityFrameworkCore;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiRVM2019.Controllers.Dashboard
{
    [Route("[controller]")]
    [ApiController]
    public class V_TotalReclamosRealizados : ControllerBase
    {
        private readonly AppDbContext context;

        public V_TotalReclamosRealizados(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<V_TotalReclamosRealizadosController>
        [HttpGet]
        public IActionResult Get()
        {
            var data = from V_TotalReclamosRealizados in context.V_TotalReclamosRealizados
                       
                       select V_TotalReclamosRealizados;

            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        // GET api/<V_TotalReclamosRealizadosController>/5
        [HttpGet("{idUsuario}")]
        public IActionResult Get(int idUsuario)
        {
            var data = from V_TotalReclamosRealizados in context.V_TotalReclamosRealizados
                       where V_TotalReclamosRealizados.IDUsuario == idUsuario
                       select V_TotalReclamosRealizados;

            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        // POST api/<V_TotalReclamosRealizadosController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<V_TotalReclamosRealizadosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<V_TotalReclamosRealizadosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
