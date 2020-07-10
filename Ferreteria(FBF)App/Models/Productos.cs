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
        public int ProductoId { get; set; }

        [Required(ErrorMessage = "Debe de introducir la descripción")]
        public string Descripción { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir la unidad")]
        public string Unidad { get; set; }

        public int MarcaId { get; set; }
        
        [Required(ErrorMessage = "Es obligatorio introducir el precio unitario")]
        [Range(1, 99999999999999, ErrorMessage = "Es obligatorio introducir un precio unitario valido")]
        public double PrecioUnitario { get; set; }
        
        [Required(ErrorMessage = "Es obligatorio introducir el inventario")]
        [Range(1, 99999999999999, ErrorMessage = "Es obligatorio introducir una cantidad de inventario valida")]
        public int Inventario { get; set; }
        public double ValorInventario { get; set; }
        public int UsuarioId { get; set; }
    }
}
