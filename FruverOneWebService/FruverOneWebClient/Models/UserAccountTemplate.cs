using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FruverOneWebClient.Models
{
    public class UserAccountTemplate
    {
       
        [EmailAddress]
        [Required]
        [MaxLength(length: 40)]
        public string Email { get; set; }
        public string Token { get; set; }


        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }

        public int Status { get; set; }

        public object Data { get; set; }


    }
}