using ApiRVM2019.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRVM2019.Contexts
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }

        //especificacion tablas
        public DbSet<Reclamo>Reclamo{ get; set; }
        public DbSet<TipoEstado>TipoEstado{ get; set; }
        public DbSet<Estado>Estado{ get; set; }
        public DbSet<Sesion> Sesion { get; set; }
    }
}
