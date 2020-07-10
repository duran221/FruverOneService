using Datos.DbContext;
using Domain.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Control
{
    public class ControlGetProducts
    {
        readonly ResponseQuery query;

        public ControlGetProducts()
        {
            query = new ResponseQuery();
        }

        public List<Producto> GetProducts()
        {
            //List of products
            List<Producto> listProducts = new List<Producto>();
            //Consult sql
            const string commandSql = "SELECT * FROM \"producto\"";


            var data = query.ResolveQuerySelect(commandSql);
            //For to insert data
            foreach (DataRow row in data.Rows)
            {

                listProducts.Add(new Producto() { 
                idProducto = (int)row.Field<decimal>(data.Columns[0]),
                nombreProducto = row.Field<string>(data.Columns[1]),
                descripcionProducto = row.Field<string>(data.Columns[2]),
                precioProducto = (int)row.Field<decimal>(data.Columns[3]),
                ivaProducto = (int)row.Field<decimal>(data.Columns[4])
                });

                //End for
            }



            return listProducts;
        }








    }
}
