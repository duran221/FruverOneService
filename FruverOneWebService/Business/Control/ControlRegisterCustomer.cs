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
            Customer customer = this.CreateModelCustomer(dataCustomer);

            string commandSql = "INSERT INTO \"Customer\" VALUES" +
                                $"('{customer.Document}','{customer.Name}','{customer.LastName}','{customer.PhoneNumber}'," +
                                $"'{customer.Address}')";

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

            string commandSql = "INSERT INTO public.\"UserAccount\" VALUES" +
                                $"('{account.Email}','{account.Password}','{account.DocumentCustomer}')";

            bool request = query.ResolveQueryInsert(commandSql);

            return request;

        }

        private UserAccount CreateModelAccount(JObject dataCustomer)
        {
            return new UserAccount()
            {
                Email= dataCustomer["Email"].ToString(),
                Password = dataCustomer["Password"].ToString(),
                DocumentCustomer= dataCustomer["Document"].ToString()
            };

        }

        private Customer CreateModelCustomer(JObject dataCustomer)
        {
            return new Customer()
            {
                Document = dataCustomer["Document"].ToString(),
                Name = dataCustomer["Name"].ToString(),
                LastName = dataCustomer["LastName"].ToString(),
                PhoneNumber = Convert.ToInt64(dataCustomer["PhoneNumber"].ToString()),
                Address = dataCustomer["Address"].ToString()
            };

        }
        
    }
}
