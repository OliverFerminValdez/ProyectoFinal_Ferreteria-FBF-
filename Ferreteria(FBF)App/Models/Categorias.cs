﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ferreteria_FBF_App.Models
{
    public class Categorias
    {
        [Key]
        public int CategoriaId { get; set; }
        [StringLength(maximumLength: 50, MinimumLength = 3, ErrorMessage = "El nombre es muy corto")]
        [Required(ErrorMessage ="Es obligatorio introducir una descripcion")]
        public string Descripcion { get; set; }
        public int UsuarioId { get; set; }

    }
}
