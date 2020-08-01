using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.IControl;
using Datos.DbContext;
using Domain.Class;
using Newtonsoft.Json.Linq;

namespace Business.Control
{
   public  class ControlOrden : IControlOrder
    {
        readonly ResponseQuery query;

        public ControlOrden()
        {
            query = new ResponseQuery();
        }

        public Customer GetCustomer(long dateCustomer)
        {
           ControlGetCustomer controlGetCustomer = new ControlGetCustomer();
           return controlGetCustomer.GetCustomer(dateCustomer);
        }

        public bool RegisterOrder( long Document)
        {
           
            Order register = this.CreateModelOrder(Document);
             string commandSql=  "INSERT INTO orders (id_customer, date_creation, date_sent, name, address, phone, city, status)" +

          " VALUES" + $"({register.DocumentCustomer}, NOW(),NOW()," +
                                $"'{register.customerName}','{register.shippingAddress}','{register.phone}','null','{register.status}')";
            
         
            bool request = query.ResolveQueryInsert(commandSql);

            return request;
        }

        private Order CreateModelOrder(long dateCustomer)
        {
            Customer customer = this.GetCustomer(dateCustomer);
            Order order = new Order()
            {
                status = "Pendiente",
                customerName = customer.Name,
                shippingAddress = customer.Address,
                phone = customer.PhoneNumber,
                city = null,
                DocumentCustomer = customer.Document
                
            };


            return order;



        }

    }
}
