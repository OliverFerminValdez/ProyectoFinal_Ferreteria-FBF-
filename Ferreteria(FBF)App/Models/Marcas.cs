using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ferreteria_FBF_App.Models
{
    public class Marcas
    {
        [Key]
        public int MarcaId { get; set; }

        [Required(ErrorMessage = "Debe de introducir el la descripcion")]
        public string Descripcion { get; set; }
        public int UsuarioId { get; set; }
    }
}
