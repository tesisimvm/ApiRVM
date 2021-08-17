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
    public class ReclamoController : ControllerBase
    {
        private readonly AppDbContext context;

        public ReclamoController(AppDbContext context)
        {
            this.context = context;
        }
        // GET: api/<ReclamoController>
        [HttpGet]
        public IActionResult Get()
        {
            var _Reclamo = from Reclamo in context.Reclamo
                           join Estado in context.Estado on Reclamo.ID_Estado equals Estado.IDEstado
                           join TipoReclamo in context.TipoReclamo on Reclamo.ID_TipoReclamo equals TipoReclamo.IDTipoReclamo
                           join Sesion in context.Sesion on Reclamo.ID_Sesion equals Sesion.IDSesion
                           join DetalleReclamo in context.DetalleReclamo on Reclamo.ID_DetalleReclamo equals DetalleReclamo.IDDetalleReclamo
                           join Usuario in context.Usuario on Sesion.ID_Usuario equals Usuario.IDUsuario
                           select new
                           {
                               FechaR = Reclamo.Fecha,
                               HoraR = Reclamo.Hora,
                               EstadoR = Estado.Nombre,
                               AlturaR = DetalleReclamo.Altura,
                               DireccionR = DetalleReclamo.Direccion,
                               TipoReclamo = TipoReclamo.Nombre,
                               DNIUsuario = Usuario.DNI,
                               CelularUsuario = Usuario.Celular,
                               Nick = Usuario.Nick,
                               CorreoUsuario = Usuario.Correo,
                           };

            if (_Reclamo == null)
            {
                return NotFound();
            }

            return Ok(_Reclamo);
        }

        // GET api/<ReclamoController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Reclamo>> GetReclamo(int id)
        {
            var _Reclamo = await context.Reclamo.FindAsync(id);

            if (_Reclamo == null)
            {
                return NotFound();
            }

            return _Reclamo;
        }

        // POST api/<ReclamoController>
        [HttpPost]
        public ActionResult Post([FromBody] Reclamo reclamo)
        {
            try
            {
                context.Reclamo.Add(reclamo);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // PUT api/<ReclamoController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Reclamo reclamo)
        {
            if (reclamo.IDReclamo == id)
            {
                context.Entry(reclamo).State = EntityState.Modified;
                context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE api/<ReclamoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
