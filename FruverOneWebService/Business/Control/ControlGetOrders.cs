using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.IControl;
using Datos.DbContext;
using Domain.Class;

namespace Business.Control
{
    public class ControlGetOrders : IControlGetOrders
    {
        readonly ControlGetCustomer controlGetCustomer;
        readonly ResponseQuery query;

        public ControlGetOrders()
        {
            this.controlGetCustomer = new ControlGetCustomer();
            query = new ResponseQuery();
        }

        /// <summary>
        /// Obtiene una Orden de pedido solicitando como criterio el id de la orden
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public Order GetOrder(int orderId)
        {
            string commandSql = $"SELECT * FROM orders WHERE order_id={orderId}";

            var data = query.ResolveQuerySelect(commandSql);

            Order order = new Order();
            foreach (DataRow row in data.Rows)
            {
                order = new Order()
                {
                    order_id = row.Field<int>(data.Columns[0]),
                    DocumentCustomer = row.Field<int>(data.Columns[1]),
                    date_creation = row.Field<DateTime>(data.Columns[2]),
                    date_sent= null,
                    customerName = row.Field<string>(data.Columns[3]),
                    shippingAddress = row.Field<string>(data.Columns[4]),
                    phone = row.Field<string>(data.Columns[5]),
                    city = row.Field<string>(data.Columns[6]),
                    status = row.Field<string>(data.Columns[7])
                };
            }
            return order;

        }

        /// <summary>
        /// Permite consultar los detalles de una Orden de pedido
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public List<OrderDetails> GetOrderDetails(int orderId)
        {
            string commandSql = $"SELECT * FROM order_details WHERE id_order={orderId}";

            var data = query.ResolveQuerySelect(commandSql);

            List<OrderDetails> ordersDetails = new List<OrderDetails>();
            foreach (DataRow row in data.Rows)
            {
                ordersDetails.Add(new OrderDetails()
                {
                    id_OrderDatails = row.Field<int>(data.Columns[0]),
                    price_Unity =  row.Field<int>(data.Columns[1]),
                    quantity = row.Field<int>(data.Columns[2]),
                    discount = row.Field<int>(data.Columns[3]),
                    nameProduct= row.Field<string>(data.Columns[4]),
                    idOrder= row.Field<int>(data.Columns[5])
                    
                });
            }
            return ordersDetails;

        }

        /// <summary>
        /// Consulta todas las Ordenes de Pedido que hay en el sistema.
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public List<Order> GetOrders()
        {
            string commandSql = $"SELECT * FROM orders";

            var data = query.ResolveQuerySelect(commandSql);

            List<Order> orders = new List<Order>();

            foreach (DataRow row in data.Rows)
            {
                int order_id = row.Field<int>(data.Columns[0]);
                orders.Add(this.GetOrder(order_id));
            }

            return orders;
        }


        /// <summary>
        /// Consulta las todas órdenes de pedido para un cliente especifico
        /// </summary>
        /// <param name="documentCustomer"></param>
        /// <returns></returns>
        public List<Order> GetOrdersForCustomer(long documentCustomer)
        {
            string commandSql = $"SELECT order_id FROM orders WHERE id_customer={documentCustomer}";

            var data = query.ResolveQuerySelect(commandSql);

            List<Order> orders = new List<Order>();

            foreach (DataRow row in data.Rows)
            {
                int order_id = row.Field<int>(data.Columns[0]);
                orders.Add(this.GetOrder(order_id));
            }

            return orders;

        }
    }

}
