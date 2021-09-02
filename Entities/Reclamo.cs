using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRVM2019.Entities
{
    public class Reclamo
    {
        [Key]
        public int IDReclamo { get; set; }
        public DateTime Fecha { get; set; } 
        public string Foto { get; set; }
        public TimeSpan Hora { get; set; } 
        public int ID_Sesion { get; set; }
        public int ID_TipoReclamo { get; set; }
        public int ID_Estado { get; set; }
        public int ID_DetalleReclamo { get; set; }
    }
}
