using Business.IControl;
using Datos.DbContext;
using Domain.Class;
using Newtonsoft.Json.Linq;
using System;
using System.Data;


namespace Business.Control
{
    public class ControlAuthenticateUser : IControlAuthenticateUser
    {

        readonly ResponseQuery query;

        public ControlAuthenticateUser()
        {
            query = new ResponseQuery();
        }

        /// <summary>
        /// Permite a un usuario iniciar sesión en la plataforma a partir de sus datos email y contraseña
        /// </summary>
        /// <param name="userCredentials">JSON Con la información de sesión del usuario email y contraseña</param>
        /// <returns>Si el inicio de sesión fué exitoso retorna un Modelo 'UserAccount' con las credenciales de sesión</returns>
        public UserAccount Login(JObject userCredentials)
        {
            string email = userCredentials["Email"].ToString();
            string password = userCredentials["Password"].ToString();

            string passwordEncrypt = Util.Encrypt.EncryptSHA256(password);
            string commandSql = $"SELECT * FROM user_accounts WHERE email='{email}' and password='{passwordEncrypt}'" +
                $"and id_status=1";

            var data = query.ResolveQuerySelect(commandSql);
            UserAccount accountUser = new UserAccount();    
            return GetUserAccount(data, accountUser);

           
        }

        /// <summary>
        /// Construye un modelo de tipo UserAccount a partir de una tabla producto de una consulta en la base de datos
        /// </summary>
        /// <param name="data">Objeto tabla que contiene los datos de la consulta en la base de datos</param>
        /// <param name="user">Modelo vacio UserAccount</param>
        /// <returns>Modelo UserAccount con la información del Usuario, si no existe datos en la tabla retorna un modelo vacío</returns>
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
        /// Actualiza un token generado en la base de datos de un usuario específico.
        /// </summary>
        /// <param name="user">Modelo que contiene la información del usuario al que se le va a actualizar el token</param>
        /// <returns>Verdadero si el token fué actualizado con éxito, false, de lo contrario</returns>
        private bool SaveToken(UserAccount user)
        {
            string commandSql = $"UPDATE  user_accounts SET token='{user.Token}'" +
                $" WHERE email='{user.Email}'";

            bool request = query.ResolveQueryInsert(commandSql);
            return request;
        }


        /// <summary>
        /// Genera un token aleatorio como producto de un intento de inicio de sesión exitoso
        /// </summary>
        /// <returns>Cadena alfanúmerica con el token generado</returns>
        public string GetToken() =>  Guid.NewGuid().ToString();


        /// <summary>
        /// Permite verificar si un token existe en la plataforma, si el token existe, el usuario tiene acceso a los servicios.
        /// </summary>
        /// <param name="token">token enviado para el cliente para verificar su existencia</param>
        /// <returns>Verdadero si el token existe en la base de datos, Falso de lo contrario</returns>
        public bool VerifyToken(string token)
        {

            string commandSql = $"SELECT * FROM user_accounts WHERE token= '{token}'" +
                $"and id_status=1";

            var data = query.ResolveQuerySelect(commandSql);

            return data.Rows.Count > 0;
        }
    }
}
  