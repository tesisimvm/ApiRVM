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
    public class VehiculoXDetalleRController : ControllerBase
    {
        private readonly AppDbContext context;

        public VehiculoXDetalleRController(AppDbContext context)
        {
            this.context = context;
        }
        // GET: api/<VehiculoXDetalleRController>
        [HttpGet]
        public IActionResult Get()
        {

            var _VehiculoXDetalleR = from VehiculoXDetalleReclamo in context.VehiculoXDetalleReclamo
                                     join DetalleReclamo in context.DetalleReclamo on VehiculoXDetalleReclamo.ID_DetalleReclamo equals DetalleReclamo.IDDetalleReclamo
                                     //join Vehiculo in context.Vehiculo on VehiculoXDetalleReclamo.ID_Vehiuclo equals vehiculo.IDVehiuclo
                                     //superconsulta como la del reclamo
                                     select new
                              {
                                  //mostar todos los daos del vehiculo y su estado
                              };

            if (_VehiculoXDetalleR == null)
            {
                return NotFound();
            }
            return Ok(_VehiculoXDetalleR);
        }

        // GET api/<VehiculoXDetalleRController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VehiculoXDetalleReclamo>> GetVehiculoXDetalleR(int id)
        {
            var _VehiculoXDetalle = await context.VehiculoXDetalleReclamo.FindAsync(id);

            if (_VehiculoXDetalle == null)
            {
                return NotFound();
            }

            return _VehiculoXDetalle;
        }

        // POST api/<VehiculoXDetalleRController>
        [HttpPost]
        public ActionResult Post([FromBody] VehiculoXDetalleReclamo _VehiculoXDetalle)
        {
            try
            {
                context.VehiculoXDetalleReclamo.Add(_VehiculoXDetalle);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // PUT api/<VehiculoXDetalleRController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] VehiculoXDetalleReclamo _VehiculoXDetalle)
        {
            if (_VehiculoXDetalle.IDVXDetalleReclamo == id)
            {
                context.Entry(_VehiculoXDetalle).State = EntityState.Modified;
                context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE api/<VehiculoXDetalleRController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
