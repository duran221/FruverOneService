using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Class
{
    public class Product
    {
        public String cod_product { get; }
        public String name { get; }
        public String description { get; }
        public float preci { get; }
        public int quantity { get; }
        public float discount { get; }
        public float iva { get; }
        public String image_url { get; }


        public Product(String cod_product, String name, String description, float preci, 
            int quantity, float discount, float iva, String image_url) {
            this.cod_product = cod_product;
            this.name = name;
            this.description = description;
            this.preci = preci;
            this.quantity = quantity;
            this.discount = discount;
            this.iva = iva;
            this.image_url=image_url;
        }
    }
}
