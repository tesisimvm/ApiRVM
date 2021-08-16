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
	public class PerfilController : ControllerBase
	{
		private readonly AppDbContext context;
		public PerfilController(AppDbContext context)
		{
			this.context = context;
		}

		// GET: api/<PerfilController>
		[HttpGet]
		public IActionResult Get()
		{
			var _Perfil = from Perfil in context.Perfil
						 select Perfil;

			if (_Perfil == null)
			{
				return NotFound();
			}
			return Ok(_Perfil);
		}

		// GET api/<PerfilController>/5
		[HttpGet("{id}")]
		public string Get(int id)
		{
			return "value";
		}

		// POST api/<PerfilController>
		[HttpPost]
		public void Post([FromBody] string value)
		{
		}

		// PUT api/<PerfilController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<PerfilController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
