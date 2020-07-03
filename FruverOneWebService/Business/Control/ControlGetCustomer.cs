using Datos.DbContext;
using Domain.Class;
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
            const string commandSql = "SELECT * FROM PUBLIC.\"Customer\"";

            var data = query.ResolveQuerySelect(commandSql);
            foreach (DataRow row in data.Rows)
            {
                listCustomers.Add(new Customer()
                {
                    Document = row.Field<string>(data.Columns[0]),
                    Name = row.Field<string>(data.Columns[1]),
                    LastName = row.Field<string>(data.Columns[2]),
                    PhoneNumber = (long)row.Field<decimal>(data.Columns[3]),
                    Address = row.Field<string>(data.Columns[4])
                });

            }

            return listCustomers;
        }


        /// <summary>
        /// Obtiene los datos personales de un cliente registrado en la plataforma a partir de su documento
        /// </summary>
        /// <param name="documentCustomer">Documento del cliente (Customer)</param>
        /// <returns>Objeto Customer con la información del cliente consultado, 
        /// si el cliente no existe se retorna un objeto con atributos vacios</returns>
        public Customer GetCustomer(string documentCustomer)
        {
            return new Customer();
        }

    }
}
