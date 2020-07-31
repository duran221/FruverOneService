using Datos.DbContext;
using Domain.Class;
using Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Data;

namespace Business.Control
{
    public class ControlGetCustomer
    {

        readonly ResponseQuery query;

        public ControlGetCustomer()
        {
            query = new ResponseQuery();
        }


        /// <summary>
        /// Consulta y retorna una lista con la información de todos los clientes registrados en la
        /// Plataforma.
        /// </summary>
        /// <returns>Lista con los clientes almacenados en la base de datos</returns>
        public List<Customer> GetCustomers()
        {
            List<Customer> listCustomers = new List<Customer>();
            const string commandSql = "SELECT document FROM customers";

            var data = query.ResolveQuerySelect(commandSql);
            foreach (DataRow row in data.Rows)
            {
                long document = Int64.Parse(row.Field<string>(data.Columns[0]));
                listCustomers.Add(this.GetCustomer(document));

            }

            return listCustomers;
        }


        /// <summary>
        /// Obtiene los datos personales de un cliente registrado en la plataforma a partir de su documento
        /// </summary>
        /// <param name="documentCustomer">Documento del cliente (Customer)</param>
        /// <returns>Objeto Customer con la información del cliente consultado, 
        /// si el cliente no existe se retorna un objeto con atributos vacios</returns>
        public Customer GetCustomer(long documentCustomer)
        {
            
            string commandSql = $"SELECT * FROM customers WHERE document='{documentCustomer}'";

            var data = query.ResolveQuerySelect(commandSql);

            Customer customer= new Customer();
            foreach (DataRow row in data.Rows)
            {
                customer = new Customer()
                {
                    Document = Int64.Parse(row.Field<string>(data.Columns[0])),
                    Name = row.Field<string>(data.Columns[1]),
                    LastName = row.Field<string>(data.Columns[2]),
                    PhoneNumber = row.Field<string>(data.Columns[3]),
                    Email = row.Field<string>(data.Columns[4]),
                    NameOrganization = row.Field<string>(data.Columns[5]),
                    ZipCode = row.Field<string>(data.Columns[6]),
                    Address = row.Field<string>(data.Columns[7])
                };
            }
            return customer;
        }

    }
}
