﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRVM2019.Entities
{
    public class ReclamoAmbiental
    {
        [Key]
        public int IDReclamoAmbiental { get; set; }
        public string NombreReclamoAmbiental { get; set; }
    }
}
