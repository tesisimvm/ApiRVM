using ApiRVM2019.Contexts;
using ApiRVM2019.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
	public class UsuarioController : ControllerBase
	{
		private readonly AppDbContext context;

		public UsuarioController(AppDbContext context)
		{
			this.context = context;
		}

		// GET: api/<UsuarioController>
		[HttpGet]
		public IActionResult Get()
		{
			var _Usuario = from Usuario in context.Usuario
						   select Usuario;

			if(_Usuario == null)
			{
				return NotFound();
			}
			return Ok (_Usuario);
		}

		// GET api/<UsuarioController>/5
		[HttpGet("{id}")]
		public string Get(int id)
		{
			return "value";
		}

		// POST api/<UsuarioController>
		[HttpPost]
		public void Post([FromBody] string value)
		{
		}

		// PUT api/<UsuarioController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<UsuarioController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
