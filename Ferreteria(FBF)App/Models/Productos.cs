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
        [StringLength(30, ErrorMessage = "La descripcion debe contener al menos 4 digitos", MinimumLength = 4)]
        public string Descripción { get; set; }

        [StringLength(maximumLength: 30, MinimumLength = 4, ErrorMessage = "El nombre es muy corto")]
        [Required(ErrorMessage = "Es obligatorio introducir la unidad")]
        public string Unidad { get; set; }

        [Display(Name = "Elija una marca")]
        [Required(ErrorMessage = "Debe seleccionar una marca")]
        public int MarcaId { get; set; }

        [Display(Name = "Elija una categoria")]
        [Required(ErrorMessage ="Debe seleccionar una categoria")]
        public int CategoriaId { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir el precio unitario")]
        [Range(1, 99999999999999, ErrorMessage = "Es obligatorio introducir un precio unitario valido")]
        public double PrecioUnitario { get; set; }
        public int Inventario { get; set; }
        public double ValorInventario { get; set; }
        public int UsuarioId { get; set; }
    }
}
