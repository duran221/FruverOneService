using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Class
{
    public class UserAccount
    {
        
        public string Email { get;}

        public  string Password { get; set; }
        public int? IdStatus { get; }
        public int? Token { get; set; }
        public string Role { get;}

        public UserAccount(String email, string password, string role)
        {
            this.Email = email;
            this.Password = password;
            this.Role = role;
            this.IdStatus = null;
            this.Token = null;
        }



    }
}
