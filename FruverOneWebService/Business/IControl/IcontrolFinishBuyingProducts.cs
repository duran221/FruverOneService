using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Business.IControl
{
   interface IcontrolFinishBuyingProducts
   {
        bool ConfirmPurchaseProduct();
        bool RegisterPurchaseProduct(JObject dataPurchase);

   }
}
