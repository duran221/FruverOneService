using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Class
{
    public class CartDetails
    {
        public int idCartDetails { get; }
        public int quantity { get; }
        public float costUnity { get; }
        public float subTotal { get; set; }


    }
}
