using Business.IControl;
using Datos.DbContext;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Business.Control
{
    public class ControlGetProduct : IControlGetProduct
    {
        readonly ResponseQuery query;

        public ControlGetProduct() {

            this.query = new ResponseQuery();
        }

        /// <summary>
        /// Lista de nombres de productos que ofrece FruverOne a sus clientes y usuarios
        /// </summary>
        /// <returns>Objeto tipo JSON contiene el listado de nombre de los productos (Frutas y verduras)</returns>
        public JObject getNamesProducts()
        {
            const string commandSql = "SELECT * FROM public.\"listnameproducts\"";
            var data = query.ResolveQuerySelect(commandSql);
            List<string> namesList = new List<string>();
            foreach (DataRow row in data.Rows)
            {
                namesList.Add(row.Field<string>(data.Columns[0]).Trim());
            }

            string jsonNames = @"{ 'items': [";
            for (int i=0; i<namesList.Count; i++) {
                if (i == namesList.Count - 1)
                {
                    jsonNames += @"'" + namesList[i] + @"'";
                }
                else {
                    jsonNames += @"'"+namesList[i] + @"',";
                }
            }

            jsonNames += @"]}";
            JObject productJSON = JObject.Parse(jsonNames);

            return productJSON;

        }
        /// <summary>
        /// Muestra los datos de un producto en específico para realizar la compra
        /// </summary>
        /// <returns> Objeto de tipo JSON con la información del producto</returns>
        public JObject getProduct(string nameProduct)
        {
            string commandSql = "SELECT * FROM public.product('" + nameProduct + "')";
            var data = query.ResolveQuerySelect(commandSql);

            String queryProd = @"{";

            foreach (DataRow row in data.Rows)
            {

                queryProd += @"'COD':'" + row.Field<string>(data.Columns[0]).Trim() + "',"; //Cod
                queryProd += @"'NameCategory':'"+ row.Field<string>(data.Columns[1]).Trim() + "',"; //Categoria
                queryProd += @"'Name':'"+row.Field<string>(data.Columns[2]).Trim() + "',"; //Nameproduct
                queryProd += @"'Description':'" + row.Field<string>(data.Columns[3]).Trim() + "',";//Description
                queryProd += @"'Price':" + row.Field<Int32>(data.Columns[4]) + ",";
                queryProd += @"'Discount':" + float.Parse(row.Field<Decimal>(data.Columns[5]).ToString()) + ",";
                queryProd += @"'Image_url':'" + row.Field<string>(data.Columns[6]).Trim() + "',";
                queryProd += @"'Quantity':" + row.Field<Int32>(data.Columns[7]) + "}";
            }

            JObject productJSON = JObject.Parse(queryProd);

            return productJSON;
            
        }
    }
}
