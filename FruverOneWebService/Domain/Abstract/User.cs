using Domain.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstract
{
    public abstract class User
    {   
        public long Document { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public UserAccount UserAccount { get; set; }


    }

    
}
