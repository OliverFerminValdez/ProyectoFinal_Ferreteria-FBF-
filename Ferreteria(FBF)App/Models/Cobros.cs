using System;
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

        //Debe de ponerse dentro de la clase de InputSelectNumber como que "Debe de seleccionar una opcion" para que sea un poco generico,
        //ya que se va a utilizar los combos con mas refencias.
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir la fecha")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir el Monto")]
        public double Monto { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir el Balance")]
        public double Balance { get; set; }

        //No le puse ninguna dataAnnotations porque se va a tomar de el usuario que este logeado.
        public int UsuarioId { get; set; }
    }
}
