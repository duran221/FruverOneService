using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Class
{
    public class Cart
    {
        public char id_Cart { get; }
        public float total { get; }
        public int quantity { get; set; }
        public DateTime fecha { get;  }

    }

}
