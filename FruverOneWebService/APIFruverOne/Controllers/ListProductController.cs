using Business.Control;
using Domain.Class;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace APIFruverOne.Controllers
{
    public class ListProductController : ApiController
    {

        private readonly ControlGetListProduct getList;

        public ListProductController() {
            this.getList = new ControlGetListProduct();
        }

        // GET: api/ListProduct
        [HttpGet]
        public List<JObject> GetFruties()
        {
            return getList.getFruties();
        }

        [HttpGet]
        public List<JObject> GetVegetals()
        {
            return getList.getVegetals();
        }

    }
}

