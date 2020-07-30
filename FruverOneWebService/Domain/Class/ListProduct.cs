using System.Collections.Generic;

namespace Domain.Class
{
    public class ListProduct
    {

       public List<Product> fruit { get; }
       public List<Product> vegetal { get; }
       public  List<Product> productStar { get; }
        public ListProduct()
        {
            this.fruit = new List<Product>();
            this.vegetal = new List<Product>();
            this.productStar = new List<Product>();
        }
        /// <summary>
        /// agregar a la lista de productos frutas
        /// </summary>
        /// <param name="fruty"></param>
        /// <returns>True si se agrega a la lista de vegetales</returns>
        public bool addFruit(Product fruty)
        {
            this.fruit.Add(fruty);

            return true;
        }
        /// <summary>
        /// agregar a la lista de productos vegetales
        /// </summary>
        /// <param name="vegetal"></param>
        /// <returns>True si se agrega a la lista</returns>
        public bool addVegetal(Product vegetal) {
            this.vegetal.Add(vegetal);
            return true;
        }
        /// <summary>
        /// agregar a la lista de productos estrellas
        /// </summary>
        /// <param name="star"></param>
        /// <returns>True si se agrega a la lista</returns>
        public bool addProductStar(Product star) {
            this.productStar.Add(star);
            return true;
        }

    }
}
