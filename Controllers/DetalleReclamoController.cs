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
            
            var _DetReclamo = from DetalleReclamo in context.DetalleReclamo                                
                           select new
                           {
                               IDDetReclamo = DetalleReclamo.IDDetalleReclamo,                               
                               AlturaR = DetalleReclamo.Altura,
                               DireccionR = DetalleReclamo.Direccion,                             
                           };

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
            var _DetReclamo = await context.DetalleReclamo.FindAsync(id);

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