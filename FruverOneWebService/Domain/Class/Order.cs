using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Class
{
    public class Order
    {

        public int order_id { get; set; }
        public string status { get; set; }
        public DateTime  date_creation { get; set; }  //MM-DD-YYYY    
        public DateTime date_sent { get; set; }
        public string customerName { get; set; }
        public string shippingAddress { get; set; }
        public string phone { get; set; }
        public string city { get; set; }
        public long DocumentCustomer { get; set; }
    }

}
