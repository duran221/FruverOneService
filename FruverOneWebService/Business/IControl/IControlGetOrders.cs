using Domain.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.IControl
{
    public interface IControlGetOrders
    {

        List<Order> GetOrders();

        Order GetOrder(int orderId);

        List<Order> GetOrdersForCustomer(long documentCustomer);

        List<OrderDetails> GetOrderDetails(int orderId);


    }
        
}
