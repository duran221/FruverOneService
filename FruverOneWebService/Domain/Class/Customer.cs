using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Abstract;
namespace Domain.Class
{
    public class Customer : User
    {
        public string NameOrganization { get; set; }
        public string PhoneNumber { get; set; }
        public string ZipCode { get; set; }
        public string Address { get; set; }

        public Customer()
        {

        }

    }
}
