using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Class
{
    public class UserAccount
    {
        
        public string Email { get; set; }

        public  string Password { get; set; }
        public int? IdStatus { get; set; }
        public string Token { get; set; }   
        public string Role { get; set; }

        public UserAccount(String email, string password, string role)
        {
            this.Email = email;
            this.Password = password;
            this.Role = role;
            this.IdStatus = 1;
            this.Token = null;
        }

        public UserAccount()
        {
            this.Email = null;
            this.Password = null;
            this.Role = null;
            this.IdStatus = 0;
            this.Token = null;
        }



    }
}
