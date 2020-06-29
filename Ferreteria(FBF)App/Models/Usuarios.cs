using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ferreteria_FBF_App.Models
{
    public class Usuarios
    {
        [Key]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir el nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir el apellido")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir el email, para lograr recuperar su contraseña")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        [Phone(ErrorMessage = "Solo debe introducir numeros")]
        [Required(ErrorMessage = "Es obligatorio introducir el telefono")]
        [StringLength(10, ErrorMessage = "Debe contener 10 digitos", MinimumLength = 10)]
        public string Telefono { get; set; }
        
        [Required(ErrorMessage = "Es obligatorio introducir el usuario")]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir la contraseña")]
        [StringLength(50, ErrorMessage = "Debe contener minimo 4 digitos", MinimumLength = 4)]
        public string Contraseña { get; set; }
    }
}
//
