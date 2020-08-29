using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Class
{
    public class OrderDetails
    {

        public int id_OrderDatails { get; set; }
        public string nameProduct { get; set; }
        public int price_Unity { get; set; }
        public int quantity { get; set; }
        public int discount { get; set; }

        public int idOrder { get; set; }

    }
}