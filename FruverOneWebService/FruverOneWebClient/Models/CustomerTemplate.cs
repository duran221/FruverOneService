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

        [Required]
        [MaxLength(length: 12)]
        public string Document { get; set; }

        [Required(ErrorMessage = "No te olvides del nombre")]
        [MaxLength(length: 12)]
        public string Name { get; set; }

        [Required]
        [MaxLength(length: 12)]
        public string LastName { get; set; }

        [DataType(DataType.PhoneNumber)]
        public long PhoneNumber { get; set; }
        [Required]
        public string Address { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [PasswordPropertyText]
        [Required]
        public string Password { get; set; }

        [Compare("Password",ErrorMessage = "Las contraseñas no coinciden")]
        public string PasswordConfirmation { get; set; }
    }
}