using Business.IControl;
using Datos.DbContext;
using Domain.Abstract;
using Domain.Class;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Business.Control
{
    public class AuthenticateUser : IAuthenticateUser
    {

        readonly ResponseQuery query;

        public AuthenticateUser()
        {
            query = new ResponseQuery();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userCredentials"></param>
        /// <returns></returns>
        public UserAccount Login(JObject userCredentials)
        {
            string email = userCredentials["Email"].ToString();
            string password = userCredentials["Password"].ToString();

            string passwordEncrypt = Util.Encrypt.EncryptSHA256(password);
            string commandSql = $"SELECT * FROM customers WHERE email='{email}' and password='{passwordEncrypt}'" +
                $"and id_status=1";

            var data = query.ResolveQuerySelect(commandSql);
            UserAccount accountUser = new UserAccount();    
            return GetUserAccount(data, accountUser);

           
        }

        private  UserAccount GetUserAccount(DataTable data, UserAccount user)
        {
            foreach (DataRow row in data.Rows)
            {
                user = new UserAccount()
                {
                   
                    Email = row.Field<string>(data.Columns[0]),
                    IdStatus = row.Field<int>(data.Columns[2]),
                    Role = row.Field<string>(data.Columns[3]),
                    Token= this.GetToken()
                  
                };
            }

            if (user.Token != null)
            {
                this.SaveToken(user);
            }

            return user;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        private bool SaveToken(UserAccount user)
        {
            string commandSql = $"UPDATE  user_account SET token={user.Token}" +
                $" WHERE email={user.Email}";

            bool request = query.ResolveQueryInsert(commandSql);
            return request;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetToken() =>  Guid.NewGuid().ToString();

    }
}
