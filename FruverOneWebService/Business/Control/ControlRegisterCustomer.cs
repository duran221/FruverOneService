using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Datos.DbContext;
using Domain.Class;
using Newtonsoft.Json.Linq;

namespace Business.Control
{
    public class ControlRegisterCustomer
    {
        ResponseQuery query;

       public ControlRegisterCustomer()
        {
            query = new ResponseQuery();
        }

        /// <summary>
        /// Inserta una solicitud de registro de un nuevo cliente en la base de datos.
        /// </summary>
        /// <returns>True: El usuario ha sido registrado con éxito, False, de lo contrario</returns>
        public bool RegisterCostumer(JObject dataCustomer)
        {
            Customer customer = this.CreateModelCustomer(dataCustomer);

            string commandSql = "INSERT INTO public.\"CUSTOMER\" VALUES" +
                                $"({customer.Document},{customer.Name},{customer.LastName},{customer.PhoneNumber}," +
                                $"{customer.Address})";

            bool requestCustomer = query.ResolveQueryInsert(commandSql);

            bool requestUserAccount = this.RegisterUserAccount(dataCustomer);


            return requestCustomer && requestUserAccount;

        }
        
        /// <summary>
        /// Inserta los datos del cliente en la tabla de UserAccount
        /// </summary>
        /// <param name="dataCustomer">JSON con la información del cliente</param>
        /// <returns>True si la cuenta fué creada en la base de datos, false de lo contrario</returns>
        private bool RegisterUserAccount(JObject dataCustomer)
        {
            UserAccount account = this.CreateModelAccount(dataCustomer);

            string commandSql = "INSERT INTO public.\"USERACCOUNT\" VALUES" +
                                $"({account.Email},{account.Password},{account.DocumentCustomer})";

            bool request = query.ResolveQueryInsert(commandSql);

            return request;

        }

        private UserAccount CreateModelAccount(JObject dataCustomer)
        {
            return new UserAccount()
            {
                Email= dataCustomer["email"].ToString(),
                Password = dataCustomer["password"].ToString(),
                DocumentCustomer= dataCustomer["document"].ToString()
            };

        }

        private Customer CreateModelCustomer(JObject dataCustomer)
        {
            return new Customer()
            {
                Document = dataCustomer["document"].ToString(),
                Name = dataCustomer["name"].ToString(),
                LastName = dataCustomer["lastname"].ToString(),
                PhoneNumber = Int16.Parse(dataCustomer["phonenumber"].ToString()),
                Address = dataCustomer["address"].ToString()
            };

        }
        

        /// <summary>
        /// Consulta y retorna una lista con la información de todos los clientes registrados en la
        /// Plataforma.
        /// </summary>
        /// <returns>Lista con los clientes almacenados en la base de datos</returns>
        public List<Customer> GetCustomers()
        {
            List<Customer> listCustomers = new List<Customer>();
            const string commandSql = "SELECT * FROM PUBLIC.\"CUSTOMER\"";

            var data = query.ResolveQuerySelect(commandSql);
            foreach (DataRow row in data.Rows)
            {
                listCustomers.Add(new Customer()
                {
                    Document = row.Field<string>(data.Columns[0]),
                    Name = row.Field<string>(data.Columns[1]),
                    LastName = row.Field<string>(data.Columns[2]),
                    PhoneNumber = row.Field<int>(data.Columns[3]),
                    Address = row.Field<string>(data.Columns[4])
                });
               
            }

            return listCustomers;

        }

    }
}
