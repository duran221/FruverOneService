using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Class
{
    public class ListProduct
    {

       public List<Product> fruty { get; }
       public List<Product> vegetal { get; }
       public  List<Product> productStar { get; }
        public ListProduct()
        {
            this.fruty = new List<Product>();
            this.vegetal = new List<Product>();
            this.productStar = new List<Product>();
        }

        public void addFruty(Product fruty)
        {
            this.fruty.Add(fruty);
        }
        public void addVegetal(Product vegetal) {
            this.vegetal.Add(vegetal);
        }
        public void addProductStar(Product star) {
            this.productStar.Add(star);
        }

    }
}
