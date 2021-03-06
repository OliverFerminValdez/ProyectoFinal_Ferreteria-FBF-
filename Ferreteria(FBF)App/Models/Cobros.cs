﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ferreteria_FBF_App.Models
{
    public class Cobros
    {
        [Key]
        public int CobroId { get; set; }
        [Required(ErrorMessage = "Es obligatorio elegir un cliente")]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir la fecha")]
        public DateTime Fecha { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Es obligatorio introducir el monto")]
        [Range(1, 99999999999999, ErrorMessage = "Es obligatorio introducir un monto valido")]
        public double Monto { get; set; }
        public double Balance { get; set; }
        public int UsuarioId { get; set; }
    }
}
