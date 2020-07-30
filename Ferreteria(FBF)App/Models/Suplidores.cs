﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ferreteria_FBF_App.Models
{
    public class Suplidores
    {
        [Key]
        public int SuplidorId { get; set; }
        [Required(ErrorMessage ="Es obligatorio introducir el nombre")]
        public string NombreSuplidor { get; set; }
        public int UsuarioId { get; set; }

    }
}