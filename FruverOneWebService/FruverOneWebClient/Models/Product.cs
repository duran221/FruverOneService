using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FruverOneWebClient.Models
{
    public class Product
    {
        public String COD { get; }
        public String Name { get; }
        public String Description { get; }
        public int Quantity { get; }
        public float Price { get; }
        public float Discount { get; }
        public float IVA { get; }
        public String Image_url { get; }

        public Product (String COD, String Name, String Description, int Quantity, float Price, float Discount, float IVA, String Image_url)
        {
            this.COD = COD;
            this.Name = Name;
            this.Description = Description;
            this.Quantity = Quantity;
            this.Price = Price;
            this.Discount = Discount;
            this.IVA = IVA;
            this.Image_url = Image_url;
        }
    }
}