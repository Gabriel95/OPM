using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OpmPatientsSite.Models.Patient
{
    public class PatientModel
    {
        [Required(ErrorMessage = "Debe ingresar Nombre Completo")]
        [Display(Name = "Nombre Completo")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Debe ingresar Dirección")]
        [Display(Name = "Dirección")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Debe ingresar Edad")]
        [Display(Name = "Edad")]
        [Range(0,120)]
        public int Age { get; set; }

        [Required(ErrorMessage = "Debe ingresar Ocupación")]
        [Display(Name = "Ocupación")]
        public string Occupation { get; set; }

        [Required(ErrorMessage = "Debe ingresar Correo Elctrónico")]
        [Display(Name = "Correo Electrónico")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Debe ingresar Numerto de Telefono")]
        [Display(Name = "Numero de Telefono")]
        [Phone]
        public string PhoneNumber { get; set; }


    }
}