using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ferreteria_FBF_App.Models
{
    public class Productos
    {
        [Key]
        public int ProdcutoId { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir la descripción")]
        public string Descripción { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir la unidad")]
        public string Unidad { get; set; }
        
        //Debe de ponerse dentro de la clase de InputSelectNumber como que "Debe de seleccionar una opcion" para que sea un poco generico,
        //ya que se va a utilizar los combos con mas refencias.
        public int MarcaId { get; set; }
        
        [Required(ErrorMessage = "Es obligatorio introducir el precio unitario")]
        public double PrecioUnitario { get; set; }
        
        [Required(ErrorMessage = "Es obligatorio introducir el inventario")]
        public int Inventario { get; set; }
        
        [Required(ErrorMessage = "Es obligatorio introducir el valor de inventario")]
        public double ValorInventario { get; set; }
       
        //No le puse ninguna dataAnnotations porque se va a tomar de el usuario que este logeado.
        public int UsuarioId { get; set; }
    }
}
