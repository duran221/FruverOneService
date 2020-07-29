using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Class
{
    public class UserAccount
    {
        public int Id { get; }
        public string Email { get; set; }
        public  string Password { get; set; }
        public string DocumentCustomer { get; set; }

    }
}
