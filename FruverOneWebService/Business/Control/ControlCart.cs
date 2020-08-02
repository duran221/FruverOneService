using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.IControl;
using Datos.DbContext;

namespace Business.Control
{
    public class ControlCart : IControlCart
    {
        readonly ResponseQuery query;

        public ControlCart()
        {
            query = new ResponseQuery();
        }

        public bool GetCartDetails()
        {
            throw new NotImplementedException();
        }
        public bool DeleteCartDetails(int CartDetails)
        {
            string commandSql = "DELETE FROM cart_details WHERE \"cod_Id\" = " + CartDetails + ";";
            bool eliminar = query.ResolveQueryDelete(commandSql);
            return eliminar;
        }

        public bool UpdateQuantity()
        {
            throw new NotImplementedException();
        }

        public void ViewCartDetails()
        {
            throw new NotImplementedException();
        }
        public float CalcPrice()
        {
            throw new NotImplementedException();
        }
    }
}