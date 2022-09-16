using ApiRVM2019.Contexts;
using ApiRVM2019.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiRVM2019.Controllers.Configuracion
{
    [EnableCors("All")]
    [Route("[controller]")]
    [ApiController]
    public class MarcaXModeloAdminController : ControllerBase
    {
        private readonly AppDbContext context;

        public MarcaXModeloAdminController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<MarcaXModeloAdminController>
        [HttpGet]
        public IActionResult GetMarcaxModelo()
        {
            var data = (from MarcaXModelos in context.MarcaxModelo
                        join marca in context.MarcaVehiculo on MarcaXModelos.ID_Marca equals marca.IDMarca
                        join modelo in context.ModeloVehiculo on MarcaXModelos.ID_Modelo equals modelo.IDModelo
                        select new
                        { 
                            idmarca = MarcaXModelos.ID_Marca,
                            idmodelo = MarcaXModelos.ID_Modelo
                        });
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        // GET api/<MarcaXModeloAdminController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MarcaXModeloAdminController>
        [HttpPost]
        public ActionResult PostMarcaxModelo([FromBody] MarcaXModelo objmarcaxmodelo)
        {
            try
            {
                context.MarcaxModelo.Add(objmarcaxmodelo);
                context.SaveChanges();

                //reclamo.IDReclamo = recl.Entity.IDReclamo;

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // PUT api/<MarcaXModeloAdminController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MarcaXModeloAdminController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
