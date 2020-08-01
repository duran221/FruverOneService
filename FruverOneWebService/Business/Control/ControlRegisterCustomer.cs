using System;

using Datos.DbContext;
using Domain.Class;
using Domain.Abstract;
using Newtonsoft.Json.Linq;
using Business.IControl;

namespace Business.Control
{
    public class ControlRegisterCustomer : IControlRegisterCostumer
    {
        readonly ResponseQuery query;

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
            bool requestUserAccount = this.RegisterUserAccount(dataCustomer);

            Customer customer = this.CreateModelCustomer(dataCustomer);

            string commandSql = "INSERT INTO customers VALUES" +
                                $"('{customer.Document}','{customer.Name}','{customer.LastName}'," +
                                $"'{customer.PhoneNumber}','{customer.Email}','{customer.NameOrganization}'," +
                                $"'{customer.ZipCode}','{customer.Address}')";

            bool requestCustomer = query.ResolveQueryInsert(commandSql);

            

            return requestCustomer && requestUserAccount;

        }
        
        /// <summary>
        /// Inserta los datos del cliente en la tabla de UserAccount
        /// </summary>
        /// <param name="dataCustomer">JSON con la información del cliente</param>
        /// <returns>True si la cuenta fué creada en la base de datos, false de lo contrario</returns>
        public bool RegisterUserAccount(JObject dataCustomer)
        {
            UserAccount account = this.CreateModelAccount(dataCustomer);

            string commandSql = "INSERT INTO user_accounts VALUES" +
                                $"('{account.Email}','{account.Password}',null,'{account.Role}',null)";

            bool request = query.ResolveQueryInsert(commandSql);

            return request;

        }

        /// <summary>
        /// Construye un objeto de tipo UserAccount, a partir de un archivo JSON
        /// </summary>
        /// <param name="dataCustomer">JSON con la información ingresada por el cliente</param>
        /// <returns>objeto UserAccount con todos sus atributos</returns>
        private UserAccount CreateModelAccount(JObject dataCustomer)
        {
            string email = dataCustomer["Email"].ToString();
            string password = dataCustomer["Password"].ToString();
            const string role = "client";

            return new UserAccount(email, password, role);

        }

        /// <summary>
        ///  Construye un objeto de tipo Customer, a partir de un archivo JSON 
        /// </summary>
        /// <param name="dataCustomer">JSON con la información ingresada por el cliente</param>
        /// <returns>objeto Customer con todos sus atributos</returns>
        private Customer CreateModelCustomer(JObject dataCustomer)
        {
            Customer client = new Customer()
                {
                    Document = (long) dataCustomer["Document"],
                    Name = dataCustomer["Name"].ToString(),
                    LastName = dataCustomer["LastName"].ToString(),
                    PhoneNumber = dataCustomer["PhoneNumber"].ToString(),
                    Email = dataCustomer["Email"].ToString(),
                    NameOrganization = dataCustomer["NameOrganization"].ToString(),
                    ZipCode = dataCustomer["ZipCode"].ToString(),
                    Address = dataCustomer["Address"].ToString()
                };

            client.UserAccount = this.CreateModelAccount(dataCustomer);
            return client;



        }


    }
}
