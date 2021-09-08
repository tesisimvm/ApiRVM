using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ApiRVM2019.Contexts;
using ApiRVM2019.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiRVM2019.Controllers
{
    [EnableCors("All")]
    [Route("[controller]")]
    [ApiController]
    public class DetalleReclamoController : ControllerBase
    {
        private readonly AppDbContext context;

        public DetalleReclamoController(AppDbContext context)
        {
            this.context = context;
        }
        // GET: api/<DetalleReclamoController>
        [HttpGet]
        public IActionResult Get()
        {
            var _DetReclamo = (from DetalleReclamo in context.DetalleReclamo
                              join reclamo in context.Reclamo on DetalleReclamo.ID_Reclamo equals reclamo.IDReclamo
                              join estado in context.Estado on reclamo.ID_Estado equals estado.IDEstado
                              join tipoestado in context.TipoEstado on estado.ID_TipoEstado equals tipoestado.IDTipoEstado
                              join sesion in context.Sesion on reclamo.ID_Sesion equals sesion.IDSesion
                              join usuario in context.Usuario on sesion.ID_Usuario equals usuario.IDUsuario
                              select new
                              {
                                  IDrecla = reclamo.IDReclamo,
                                  IDDetReclamo = DetalleReclamo.IDDetalleReclamo,
                                  DescripcionDR = DetalleReclamo.Descripcion,
                                  AlturaR = DetalleReclamo.Altura,
                                  DireccionR = DetalleReclamo.Direccion,
                                  ID_reclamo = DetalleReclamo.ID_Reclamo,
                                  fechaR = reclamo.Fecha,
                                  horaR = reclamo.Hora,
                                  estadoR = estado.Nombre,
                                  estadoid = estado.IDEstado,
                                  estadoT = tipoestado.nombre,
                                  estadoTid = tipoestado.IDTipoEstado,
                                  usuarioR = usuario.Nick,

                              }).OrderBy(ID => ID.IDrecla);
           

            if (_DetReclamo == null)
            {
                return NotFound();
            }
            return Ok(_DetReclamo);
        }

        // GET api/<DetalleReclamoController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DetalleReclamo>> GetDetalleReclamo(int id)
        {
            var _DetReclamo = await context.DetalleReclamo.FindAsync(from DetalleReclamo in context.DetalleReclamo
                                                                     join Reclamo in context.Reclamo on DetalleReclamo.ID_Reclamo equals Reclamo.IDReclamo
                                                                     join Sesion in context.Sesion on Reclamo.ID_Sesion equals Sesion.IDSesion
                                                                     join Usuario in context.Usuario on Sesion.ID_Usuario equals Usuario.IDUsuario
                                                                     join TipoReclamo in context.TipoReclamo on Reclamo.ID_TipoReclamo equals TipoReclamo.IDTipoReclamo
                                                                     join Estado in context.Estado on Reclamo.ID_Estado equals Estado.IDEstado
                                                                     where Usuario.IDUsuario == id
                                                                     select new
                                                                     {
                                                                         TipoReclamo = TipoReclamo.Nombre,
                                                                         Descripcion = DetalleReclamo.Descripcion,
                                                                         Fecha = Reclamo.Fecha,
                                                                         Hora = Reclamo.Hora,
                                                                         Foto = Reclamo.Foto,
                                                                         Estado = Estado.Nombre,
                                                                         Direccion = DetalleReclamo.Direccion
                                                                     });

            if (_DetReclamo == null)
            {
                return NotFound();
            }

            return _DetReclamo;
        }

        // POST api/<DetalleReclamoController>
        [HttpPost]
        public ActionResult Post([FromBody] DetalleReclamo DetReclamo)
        {
            try
            {
                context.DetalleReclamo.Add(DetReclamo);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // PUT api/<DetalleReclamoController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] DetalleReclamo DetReclamo)
        {
            if (DetReclamo.IDDetalleReclamo == id)
            {
                context.Entry(DetReclamo).State = EntityState.Modified;
                context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE api/<DetalleReclamoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
