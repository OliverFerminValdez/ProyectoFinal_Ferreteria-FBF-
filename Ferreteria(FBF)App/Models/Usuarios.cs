using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
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
        [EmailAddress(ErrorMessage ="Introduzca una direccion valida")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Es obligatorio seleccionar el nivel de acceso")]
        public string NivelAcceso { get; set; }

        [Phone(ErrorMessage = "Solo debe introducir numeros")]
        [Required(ErrorMessage = "Es obligatorio introducir el telefono")]
        [StringLength(10, ErrorMessage = "Debe contener 10 digitos", MinimumLength = 10)]
        public string Telefono { get; set; }
        
        [Required(ErrorMessage = "Es obligatorio introducir el usuario")]
        public string Usuario { get; set; }

        [RegularExpression("({(?=.*[a - z])(?=.*[A - Z]).{8,}}|{(?=.*[A - Z])(?!.*\\s).{8,}})",ErrorMessage ="Elija una contraseña segura")]
        [Required(ErrorMessage = "Es obligatorio introducir la contraseña")]
        [StringLength(50, ErrorMessage = "Debe contener minimo 4 digitos", MinimumLength = 4)]
        public string Contraseña { get; set; }

        public static string Encriptar(string Contraseña)//Esta función encripta la cadena que se le pasa por parámentro
        {
            if (!string.IsNullOrEmpty(Contraseña))
            {       
                string resultado = string.Empty;
                byte[] encryted = System.Text.Encoding.Unicode.GetBytes(Contraseña);
                resultado = Convert.ToBase64String(encryted);

                return resultado;
            }

            return string.Empty;
        }

        public static string DesEncriptar(string Contraseña)//Esta función desencripta la cadena que se le pasa por parámentro
        {
            if (!string.IsNullOrEmpty(Contraseña))
            {
                string resultado = string.Empty;
                byte[] decryted = Convert.FromBase64String(Contraseña);
                resultado = System.Text.Encoding.Unicode.GetString(decryted);
                return resultado;
            }

            return string.Empty;
        }
    }
}

