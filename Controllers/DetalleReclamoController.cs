﻿using Microsoft.AspNetCore.Cors;
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
                               join TipoReclamo in context.TipoReclamo on reclamo.ID_TipoReclamo equals TipoReclamo.IDTipoReclamo
                              // join ReclamoAmbiental in context.ReclamoAmbiental on DetalleReclamo.ID_ReclamoAmbiental equals ReclamoAmbiental.IDReclamoAmbiental
                               join sesion in context.Sesion on reclamo.ID_Sesion equals sesion.IDSesion
                               join usuario in context.Usuario on sesion.ID_Usuario equals usuario.IDUsuario
                               select new
                              {
                                  IDDetalleReclamo = DetalleReclamo.IDDetalleReclamo,
                                  Descripcion = DetalleReclamo.Descripcion,
                                  Altura = DetalleReclamo.Altura,
                                  Direccion = DetalleReclamo.Direccion,
                                  ID_Reclamo = DetalleReclamo.ID_Reclamo,
                                  Fecha = reclamo.Fecha,
                                  Hora = reclamo.Hora,
                                  Nombre = estado.Nombre,
                                  IDEstado = estado.IDEstado,
                                   NombreTRec = TipoReclamo.Nombre,
                                   IDTipoRec = TipoReclamo.IDTipoReclamo,
                                  // IDRecAmb = ReclamoAmbiental.IDReclamoAmbiental,
                                  // NombreRecAmbiental = ReclamoAmbiental.Nombre, //quema de arboles, unundaciones, etc
                                   Nick = usuario.Nick,
                                  Foto=reclamo.Foto
                              }).OrderBy(ID => ID.ID_Reclamo);
           

            if (_DetReclamo == null)
            {
                return NotFound();
            }
            return Ok(_DetReclamo);
        }

        // GET api/<DetalleReclamoController>/5
        [HttpGet("{id}")]
        public IActionResult GetReclamosUsuario(int id)
        {
            var _DetReclamo = (from DetalleReclamo in context.DetalleReclamo
                               join reclamo in context.Reclamo on DetalleReclamo.ID_Reclamo equals reclamo.IDReclamo
                               join estado in context.Estado on reclamo.ID_Estado equals estado.IDEstado
                               join TipoReclamo in context.TipoReclamo on reclamo.ID_TipoReclamo equals TipoReclamo.IDTipoReclamo
                              // join ReclamoAmbiental in context.ReclamoAmbiental on DetalleReclamo.ID_ReclamoAmbiental equals ReclamoAmbiental.IDReclamoAmbiental
                               join sesion in context.Sesion on reclamo.ID_Sesion equals sesion.IDSesion
                               join usuario in context.Usuario on sesion.ID_Usuario equals usuario.IDUsuario
                               where usuario.IDUsuario == id
                               select new
                               {
                                   IDDetalleReclamo = DetalleReclamo.IDDetalleReclamo,
                                   Descripcion = DetalleReclamo.Descripcion,
                                   Altura = DetalleReclamo.Altura,
                                   Direccion = DetalleReclamo.Direccion,
                                   ID_Reclamo = DetalleReclamo.ID_Reclamo,
                                   Fecha = reclamo.Fecha,
                                   Hora = reclamo.Hora,
                                   Nombre = estado.Nombre,
                                   IDEstado = estado.IDEstado,
                                   NombreTRec = TipoReclamo.Nombre,
                                   IDTipoRec = TipoReclamo.IDTipoReclamo,
                                  // IDRecAmb = ReclamoAmbiental.IDReclamoAmbiental,
                                  // NombreRecAmbiental = ReclamoAmbiental.Nombre, //quema de arboles, unundaciones, etc
                                   Nick = usuario.Nick,
                                   Foto = reclamo.Foto
                               }).OrderBy(ID => ID.ID_Reclamo);


            if (_DetReclamo == null)
            {
                return NotFound();
            }
            return Ok(_DetReclamo);
        }

        // POST api/<DetalleReclamoController>
        [HttpPost]
        public ActionResult Post([FromBody] DetalleReclamo DetReclamo)
        {
            try
            {
                context.DetalleReclamo.Add(DetReclamo);

                if(DetReclamo.ID_ReclamoAmbiental==0)
                {
                    DetReclamo.ID_ReclamoAmbiental = 1;
                }

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
