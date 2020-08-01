using System;
namespace Domain.Class
{
    public class Product
    {
        public String cod_product { get; }
        public String name { get; }
        public String description { get; }
        public float price { get; }
        public int quantity { get; }
        public float discount { get; }
        public float iva { get; }
        public String image_url { get; }


        public Product(String cod_product, String name, String description, int price, 
            int quantity, float discount, float iva, String image_url) {
            this.cod_product = cod_product;
            this.name = name;
            this.description = description;
            this.price = price;
            this.quantity = quantity;
            this.discount = discount;
            this.iva = iva;
            this.image_url=image_url;
        }
    }
}
