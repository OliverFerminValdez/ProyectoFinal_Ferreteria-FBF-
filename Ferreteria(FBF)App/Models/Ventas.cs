using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
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
        [Key]
        public int VentaId { get; set; }
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir la fecha")]
        [DisplayFormat(DataFormatString ="{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir el tipo de factura")]
        public string Tipo { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir el total")]
        public double Total { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir el ITBIS")]
        public double ITBIS { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir los descuentos")]
        public double Descuentos { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir el total general")]
        public double TotalGeneral { get; set; }
        public string Comentario { get; set; }
        public int CantidadProductos { get; set; }
        public int UsuarioId { get; set; }

        [ForeignKey("VentaId")]
        public virtual List<VentasDetalle> VentasDetalle { get; set; } = new List<VentasDetalle>();
    }
}
