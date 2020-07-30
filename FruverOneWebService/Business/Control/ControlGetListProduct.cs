using Business.IControl;
using Datos.DbContext;
using Domain.Class;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;


namespace Business.Control
{
    public class ControlGetListProduct : IControlGetListProduct
    {
        readonly ResponseQuery query;
        public ListProduct myList;
        public ControlGetListProduct()
        {
            this.query = new ResponseQuery();
            myList = new ListProduct();
        }

        /// <summary>
        /// Mostrar Objeto JSON con el listado de frutas
        /// </summary>
        /// <returns>JSON</returns>
        public List<JObject> getFruties() {
            this.fruits();
            List<JObject> productosJSONF = new List<JObject>();
            List<Product> frutas = myList.fruit;

            for (int n = 0; n < frutas.Count; n++)
            {
                productosJSONF.Add(
                     JObject.FromObject(new
                     {
                         COD = frutas[n].cod_product,
                         Name = frutas[n].name,
                         Description = frutas[n].description,
                         Price = frutas[n].price,
                         Quantity = frutas[n].quantity,
                         Discount = frutas[n].discount,
                         IVA = frutas[n].iva,
                         Image_url = frutas[n].image_url
                     })
                  );
            }
            return productosJSONF;
        }
        /// <summary>
        /// Mostrar Objeto JSON con el listado de vegetales
        /// </summary>
        /// <returns>JSON</returns>
        public List<JObject> getVegetals()
        {
            this.vegetals();

            List<JObject> productosJSONF = new List<JObject>();
            List<Product> vegetals = myList.vegetal;

            for (int n = 0; n < vegetals.Count; n++)
            {
                productosJSONF.Add(
                     JObject.FromObject(new
                     {
                         COD = vegetals[n].cod_product,
                         Name = vegetals[n].name,
                         Description = vegetals[n].description,
                         Price = vegetals[n].price,
                         Quantity = vegetals[n].quantity,
                         Discount = vegetals[n].discount,
                         IVA = vegetals[n].iva,
                         Image_url = vegetals[n].image_url
                     })
                  );
            }
            return productosJSONF;
        }
        /// <summary>
        /// Mostrar Objeto JSON con el listado de productos estrella
        /// </summary>
        /// <returns>JSON</returns>
        public List<JObject> getStar()
        {
            this.stars();
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
                         Price = star[n].price,
                         Quantity = star[n].quantity,
                         Discount = star[n].discount,
                         IVA = star[n].iva,
                         Image_url = star[n].image_url
                     })
                  );
            }
            return productosJSONF;
        }

        /// <summary>
        /// Construimos nuestra lista de frutas con base al acceso a la base de datos
        /// </summary>
        private void fruits()
        {
            const string commandSql = "SELECT * FROM \"frutas\"";

            var data = query.ResolveQuerySelect(commandSql);
            foreach (DataRow row in data.Rows)
            {
                string cod_product = row.Field<string>(data.Columns[0]).Trim();
                string name = row.Field<string>(data.Columns[2]).Trim();
                string description = row.Field<string>(data.Columns[3]).Trim();
                int price = row.Field<Int32>(data.Columns[4]);
                int quantity = row.Field<Int32>(data.Columns[8]);
                float discount = float.Parse(row.Field<Decimal>(data.Columns[5]).ToString());
                float iva = float.Parse(row.Field<Decimal>(data.Columns[6]).ToString());
                string image_url = row.Field<string>(data.Columns[7]).Trim();

                bool addList = myList.addFruit(new Product(cod_product, name, description, price, quantity, discount, iva, image_url));

            }

        }
        /// <summary>
        /// Construimos nuestra lista de vegetales con base al acceso a la base de datos
        /// </summary>

        private void vegetals()
        {
            const string commandSql = "SELECT * FROM \"vegetales\"";

            var data = query.ResolveQuerySelect(commandSql);
            foreach (DataRow row in data.Rows)
            {
                string cod_product = row.Field<string>(data.Columns[0]).Trim();
                string name = row.Field<string>(data.Columns[2]).Trim();
                string description = row.Field<string>(data.Columns[3]).Trim();
                int price = row.Field<Int32>(data.Columns[4]);
                int quantity = row.Field<Int32>(data.Columns[8]);
                float discount = float.Parse(row.Field<Decimal>(data.Columns[5]).ToString());
                float iva = float.Parse(row.Field<Decimal>(data.Columns[6]).ToString());
                string image_url = row.Field<string>(data.Columns[7]).Trim();

                bool addList = myList.addVegetal(new Product(cod_product, name, description, price, quantity, discount, iva, image_url));
            }
             

        }
        /// <summary>
        /// Construimos nuestra lista de productos estrellas con base al acceso a la base de datos
        /// </summary>
        private void stars()
        {
            const string commandSql = "SELECT * FROM \"star\"";
            var data = query.ResolveQuerySelect(commandSql);
            foreach (DataRow row in data.Rows)
            {
                string cod_product = row.Field<string>(data.Columns[0]).Trim();
                string name = row.Field<string>(data.Columns[2]).Trim();
                string description = row.Field<string>(data.Columns[3]).Trim();
                int price = row.Field<Int32>(data.Columns[4]);
                int quantity = row.Field<Int32>(data.Columns[8]);
                float discount = float.Parse(row.Field<Decimal>(data.Columns[5]).ToString());
                float iva = float.Parse(row.Field<Decimal>(data.Columns[6]).ToString());
                string image_url = row.Field<string>(data.Columns[7]).Trim();

                bool addList = myList.addProductStar(new Product(cod_product, name, description, price, quantity, discount, iva, image_url));
            }
        }



    }
}
