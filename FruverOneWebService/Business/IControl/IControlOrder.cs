using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Class;
using Newtonsoft.Json.Linq;

namespace Business.IControl
{
    interface IControlOrder
    {
        Customer GetCustomer(long dateCustomer);
        bool RegisterOrder(long document);

    }
}
