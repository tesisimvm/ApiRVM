using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRVM2019.Entities
{
    public class V_CantidadxEstado
    {
        public int Cantidad { get; set; }
        [Key]
        public int IDEstado { get; set; }
        public string Estado { get; set; }
        public int IDTipoEstado { get; set; }
        public string Tipo { get; set; }
    }
}
