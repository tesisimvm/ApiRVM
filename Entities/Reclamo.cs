﻿using System;
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
        public string fecha { get; set; } //date
        //public by foto { get; set; }
        public string Hora { get; set; } //string
        public string Ubicacion { get; set; }
        public int ID_Sesion { get; set; }
        public int ID_TipoReclamo { get; set; }
        public int ID_Estado { get; set; }
        public int ID_DetalleReclamo { get; set; }
    }
}
