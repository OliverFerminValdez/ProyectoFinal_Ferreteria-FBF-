using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ferreteria_FBF_App.Models
{
    public class Inventario
    {
        [Key]
        public int InventarioId { get; set; }
        [Required(ErrorMessage ="Es obligatorio introducir un suplidor")]
        public int SuplidorId { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Today;
        public double TotalInventario { get; set; }
        public int UsuarioId { get; set; }
        public virtual List<InventarioDetalle> Productos { get; set; } = new List<InventarioDetalle>();
    }
}
