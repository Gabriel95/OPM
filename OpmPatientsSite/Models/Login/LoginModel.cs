using System.ComponentModel.DataAnnotations;

namespace OpmPatientsSite.Models.Login
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Ingrese Usuario")]
        public string Username { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Ingresar Contraseña")]
        public string Password { get; set; }
    }
}