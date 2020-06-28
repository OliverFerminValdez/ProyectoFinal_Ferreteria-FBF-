using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ferreteria_FBF_App.Models
{
    public class Ventas
    {
        //Todo:Hay que evaluar las data anotations de esta entidad
        [Key]
        public int VentaId { get; set; }

        //Debe de ponerse dentro de la clase de InputSelectNumber como que "Debe de seleccionar una opcion" para que sea un poco generico,
        //ya que se va a utilizar los combos con mas refencias.
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir la fecha")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir el total")]
        public double Total { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir el ITBIS")]
        public double ITBIS { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir los descuentos")]
        public double Descuentos { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir el total general")]
        public double TotalGeneral { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir la cantidad de productos")]
        public int CantidadProductos { get; set; }

        //Entiendo que este atributo se puede obviar.
        public int ProcdutoId { get; set; }

        //No le puse ninguna dataAnnotations porque se va a tomar de el usuario que este logeado.
        public int UsuarioId { get; set; }

        [ForeignKey("VentaId")]
        public virtual List<VentasDetalle> VentasDetalle { get; set; } = new List<VentasDetalle>();
    }
}
