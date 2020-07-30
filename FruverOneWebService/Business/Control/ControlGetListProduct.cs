using DBData.DbContext;
using Domain.Class;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Control
{
    public class ControlGetListProduct
    {

        readonly ResponseQuery query;
        public ListProduct myList;
        public ControlGetListProduct()
        {
            this.query = new ResponseQuery();
            myList = new ListProduct();
            this.fruties();
            this.vegetals();
            //this.stars();
            
        }


        public List<JObject> getFruties() {

            List<JObject> productosJSONF = new List<JObject>();
            List<Product> frutas = myList.fruty;

            for (int n = 0; n < frutas.Count; n++)
            {
                productosJSONF.Add(
                     JObject.FromObject(new
                     {
                         COD = frutas[n].cod_product,
                         Name = frutas[n].name,
                         Description = frutas[n].description,
                         Price = frutas[n].preci,
                         Quantity = frutas[n].quantity,
                         Discount = frutas[n].discount,
                         IVA = frutas[n].iva,
                         Image_url = frutas[n].image_url
                     })
                  );
            }

            return productosJSONF;

        }

        public List<JObject> getVegetals()
        {
            List<JObject> productosJSONF = new List<JObject>();
            List<Product> vegetals= myList.vegetal;

            for (int n = 0; n < vegetals.Count; n++)
            {
                productosJSONF.Add(
                     JObject.FromObject(new
                     {
                         COD = vegetals[n].cod_product,
                         Name = vegetals[n].name,
                         Description = vegetals[n].description,
                         Price = vegetals[n].preci,
                         Quantity = vegetals[n].quantity,
                         Discount = vegetals[n].discount,
                         IVA = vegetals[n].iva,
                         Image_url = vegetals[n].image_url
                     })
                  );
            }
            return productosJSONF;
        }

        public List<JObject> getStar()
        {
            List<JObject> productosJSONF = new List<JObject>();
            List<Product> star = myList.productStar;

            for (int n = 0; n < star.Count; n++)
            {
                productosJSONF.Add(
                     JObject.FromObject(new
                     {
                         COD = star[n].cod_product,
                         Name = star[n].name,
                         Description = star[n].description,
                         Price = star[n].preci,
                         Quantity = star[n].quantity,
                         Discount = star[n].discount,
                         IVA = star[n].iva,
                         Image_url = star[n].image_url
                     })
                  );
            }
            return productosJSONF;
        }








        private void fruties()
        { 
            const string commandSql = "SELECT * FROM \"frutas\"";

            var data = query.ResolveQuerySelect(commandSql);
            foreach (DataRow row in data.Rows)
            {
                myList.addFruty(new Product(
                    row.Field<string>(data.Columns[0]).Trim(), //cod
                    row.Field<string>(data.Columns[1]).Trim(), //name
                    row.Field<string>(data.Columns[3]).Trim(), //description
                    float.Parse(row.Field<string>(data.Columns[4]).Trim()), //preci
                    int.Parse(row.Field<string>(data.Columns[5]).Trim()), //quantity
                    float.Parse(row.Field<string>(data.Columns[6]).Trim()), //discount
                    float.Parse(row.Field<string>(data.Columns[7]).Trim()), //iva
                     (row.Field<string>(data.Columns[8]).Trim()) //image_url
                    ));
            }

        }

        private void vegetals()
        {

              const string commandSql = "SELECT * FROM \"vegetales\"";

            var data = query.ResolveQuerySelect(commandSql);
            foreach (DataRow row in data.Rows)
            {
                myList.addFruty(new Product(
                    row.Field<string>(data.Columns[0]).Trim(), //cod
                    row.Field<string>(data.Columns[1]).Trim(), //name
                    row.Field<string>(data.Columns[3]).Trim(), //description
                    float.Parse(row.Field<string>(data.Columns[4]).Trim()), //preci
                    int.Parse(row.Field<string>(data.Columns[5]).Trim()), //quantity
                    float.Parse(row.Field<string>(data.Columns[6]).Trim()), //discount
                    float.Parse(row.Field<string>(data.Columns[7]).Trim()), //iva
                     (row.Field<string>(data.Columns[8]).Trim()) //image_url
                    ));
            }

           
        }

        private void stars()
        {
            const string commandSql = "SELECT * FROM \"star\"";

            var data = query.ResolveQuerySelect(commandSql);
            foreach (DataRow row in data.Rows)
            {
                myList.addFruty(new Product(
                    row.Field<string>(data.Columns[0]).Trim(), //cod
                    row.Field<string>(data.Columns[1]).Trim(), //name
                    row.Field<string>(data.Columns[3]).Trim(), //description
                    float.Parse(row.Field<string>(data.Columns[4]).Trim()), //preci
                    int.Parse(row.Field<string>(data.Columns[5]).Trim()), //quantity
                    float.Parse(row.Field<string>(data.Columns[6]).Trim()), //discount
                    float.Parse(row.Field<string>(data.Columns[7]).Trim()), //iva
                     (row.Field<string>(data.Columns[8]).Trim()) //image_url
                    ));
            }

          
        }



    }
}
