using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ferreteria_FBF_App.Models
{
    public class Clientes
    {
        [Key]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir el nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir el apellido")]
        public string Apellido { get; set; }

        [Phone(ErrorMessage = "Solo debe introducir numeros")]
        [Required(ErrorMessage = "Es obligatorio introducir la cedula")]
        [StringLength(11, ErrorMessage = "Debe contener 11 digitos", MinimumLength = 11)]
        public string Cedula { get; set; }

        [EmailAddress(ErrorMessage ="Introduzca una direccion valida")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir la direccion")]
        public string Dirección { get; set; }

        [Phone(ErrorMessage = "Solo debe introducir numeros")]
        [Required(ErrorMessage = "Es obligatorio introducir el telefono")]
        [StringLength(10, ErrorMessage = "Debe contener 10 digitos", MinimumLength = 10)] 
        public string Telefono { get; set; }
        
        [Required(ErrorMessage = "Debe introducir el limite de credito")]
        public double LimiteCredito { get; set; }
        public double Balance { get; set; }
        [ForeignKey("ClienteId")]
        public virtual List<CobroDetalle> Cobros { get; set; } = new List<CobroDetalle>();
        [ForeignKey("UsuarioId")]
        public int UsuarioId { get; set; }
    }
}
