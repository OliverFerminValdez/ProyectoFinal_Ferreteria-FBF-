using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ferreteria_FBF_App.Models
{
    public class VentasDetalle
    {
        //Todo:Hay que evaluar las data anotations de esta entidad + el atributo FacturaId

        [Key]
        public int VentasDetalleId { get; set; }
        public int FacturaId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public double Precio { get; set; }
        public int UsuarioId { get; set; }
    }
}
