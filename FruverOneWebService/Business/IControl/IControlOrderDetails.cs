using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Domain.Class;

namespace Business.IControl
{
    interface IControlOrderDetails
    {
        List<JObject> listDetails();
        OrderDetails GetOrderDetails();
    }
}
