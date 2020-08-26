using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.IControl
{
    interface IControlGetProduct
    {
        JObject getProduct(string nameProduct);

        JObject getNamesProducts();

    }
}
