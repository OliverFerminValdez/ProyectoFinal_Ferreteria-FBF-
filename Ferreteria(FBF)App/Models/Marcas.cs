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
        
        [Required(ErrorMessage = "Debe de introducir el nombre")]
        public string Nombre { get; set; }

        //No le puse ninguna dataAnnotations porque se va a tomar de el usuario que este logeado.
        public int UsuarioId { get; set; }
    }
}
