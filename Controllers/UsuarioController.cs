﻿using ApiRVM2019.Contexts;
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
			//Agregar a la consulta la parte del inner join cuando este lista la parte de Perfil y Estado
			var _Usuario = from Usuario in context.Usuario
						   join Estado in context.Estado on Usuario.ID_Estado equals Estado.IDEstado
						   join Perfil in context.Perfil on Usuario.ID_Perfil equals Perfil.IDPerfil
						   select new
						   {
							   nombrePerfil = Perfil.Nombre,
							   nombreEstado = Estado.Nombre,
							   nombreUsuario = Usuario.Nick,
							   correoUsuario = Usuario.Correo,
							   telefonoUsuario = Usuario.Celular,
							   dniUsuario = Usuario.DNI,
							   nombrePersona = Usuario.Nombre,
							   apellidoPersona = Usuario.Apellido,
							   nombrePerfil2=usu
						   };
			
			if (_Usuario == null)
			{
				return NotFound();
			}
			return Ok (_Usuario);
		}

		// GET api/<UsuarioController>/5
		[HttpGet("{id}")]
		public async Task<ActionResult<Usuario>> GetUsuario(int id)
		{

			var _usuario = from Usuario in context.Usuario 
						   join Estado in context.Estado on Usuario.ID_Estado equals Estado.IDEstado
						   join Perfil in context.Perfil on Usuario.ID_Perfil equals Perfil.IDPerfil
						   where Usuario.IDUsuario == id
						   select new
						   {
							   nombrePerfil = Perfil.Nombre,
							   nombreEstado = Estado.Nombre,
							   nombreUsuario = Usuario.Nick,
							   correoUsuario = Usuario.Correo,
							   telefonoUsuario = Usuario.Celular,
							   dniUsuario = Usuario.DNI,
							   nombrePersona = Usuario.Nombre,
							   apellidoPersona = Usuario.Apellido
						   };

			if (_usuario == null)
			{
				return NotFound();
			}
			
			return Ok(_usuario);
		}

		// POST api/<UsuarioController>
		[HttpPost]
		public ActionResult Post([FromBody] Usuario usuario)
		{
			try
			{
				context.Usuario.Add(usuario);
				context.SaveChanges();
				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest();
			}
		}

		// PUT api/<UsuarioController>/5
		[HttpPut("{id}")]
		public ActionResult Put(int id, [FromBody] Usuario usuario)
		{
			if (usuario.IDUsuario == id)
			{
				context.Entry(usuario).State = EntityState.Modified;
				context.SaveChanges();
				return Ok();
			}
			else
			{
				return BadRequest();
			}
		}

		// DELETE api/<UsuarioController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
