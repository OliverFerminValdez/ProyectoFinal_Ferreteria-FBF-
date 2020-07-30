using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ferreteria_FBF_App.Models
{
    public class InventarioDetalle
    {
        [Key]
        public int InventarioDetalleId { get; set; }
        public int InventarioId { get; set; }
        public int ProductoId { get; set; }
        public double costo { get; set; }
        public int Inventario { get; set; }
        public float ValorInventario { get; set; }

    }
}
