using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.IControl;
using Datos.DbContext;
using Domain.Class;
using Newtonsoft.Json.Linq;

namespace Business.Control
{
    class ControlOrderDetails : IControlOrderDetails
    {
        readonly ResponseQuery query;
      //  public ListProduct myList;
        public ControlOrderDetails()
        {
            this.query = new ResponseQuery();
           // myList = new ListProduct();
        }

        public OrderDetails GetOrderDetails()
        {
            string commandSql = "SELECT * FROM public.\"order_Details\"";
            var request = query.ResolveQuerySelect(commandSql);
            foreach (DataRow row in request.Rows)
            {
                int id_Order = row.Field<int>(request.Columns[0]);
                float price_unity = row.Field<float>(request.Columns[2]);
                int cuantity = row.Field<int>(request.Columns[3]);
                float discount = row.Field<float>(request.Columns[4]);
                string id_Product = row.Field<string>(request.Columns[8]).Trim();              

            }


        public List<JObject> listDetails()
        {
            throw new NotImplementedException();
        }
    }
}
