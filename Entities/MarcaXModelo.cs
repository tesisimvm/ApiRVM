using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRVM2019.Entities
{
    public class MarcaXModelo
    {
        [Key]
        public int IDMarcaxModelo { get; set; }
        public int ID_Marca { get; set; }
        public int ID_Modelo { get; set; }
    }
}
