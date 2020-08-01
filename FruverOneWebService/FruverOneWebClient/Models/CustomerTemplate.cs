using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FruverOneWebClient.Models
{
    public class CustomerTemplate
    {

        [Display(Name = "Nit O Documento", AutoGenerateFilter = false)]
        [Required]
        [MaxLength(length: 12)]
        public string Document { get; set; }

        [Display(Name = "Nombres", AutoGenerateFilter = false)]
        [Required(ErrorMessage = "No te olvides del nombre")]
        [MaxLength(length: 40)]
        public string Name { get; set; }

        [Display(Name = "Apellidos", AutoGenerateFilter = false)]
        [Required]
        [MaxLength(length: 40)]
        public string LastName { get; set; }

        [Display(Name = "Email", AutoGenerateFilter = false)]
        [EmailAddress]
        [Required]
        [MaxLength(length: 40)]
        public string Email { get; set; }

        [Display(Name = "Código Postal", AutoGenerateFilter = false)]
        [DataType(DataType.PostalCode)]
        public string ZipCode { get; set; }

        [Display(Name = "Empresa U Organización", AutoGenerateFilter = false)]
        [Required]
        [MaxLength(length: 40)]
        public string NameOrganization { get; set; }

        [Display(Name = "Teléfono", AutoGenerateFilter = false)]
        [Required]
        [DataType(DataType.PhoneNumber)]
        [MaxLength(length: 14)]
        [MinLength(length: 7)]
        public string PhoneNumber { get; set; }

        [Display(Name = "Dirección", AutoGenerateFilter = false)]
        [Required]
        [DataType(DataType.Text)]
        public string Address { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Contraseña", AutoGenerateFilter = false)]
        [Required]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar Contraseña", AutoGenerateFilter = false)]
        [Compare("Password", ErrorMessage = "Las contraseñas no coinciden")]
        public string PasswordConfirmation { get; set; }
    }
}