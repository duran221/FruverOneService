using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.IControl
{
    interface IControlGetListProduct
    {
        List<JObject> getFruties();
        List<JObject> getVegetals();
        List<JObject> getStar();

    }
}
