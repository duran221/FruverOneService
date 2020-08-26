using Domain.Class;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.IControl
{
    public interface IControlAuthenticateUser
    {
        /// <summary>
        /// Permite a un usuario iniciar sesión en la plataforma a partir de sus datos email y contraseña
        /// </summary>
        /// <param name="userCredentials">JSON Con la información de sesión del usuario email y contraseña</param>
        /// <returns>Si el inicio de sesión fué exitoso retorna un Modelo 'UserAccount' con las credenciales de sesión</returns>
        UserAccount Login(JObject userCredentials);

        /// <summary>
        /// Permite verificar si un token existe en la plataforma, si el token existe, el usuario tiene acceso a los servicios.
        /// </summary>
        /// <param name="token">token enviado para el cliente para verificar su existencia</param>
        /// <returns>Verdadero si el token existe en la base de datos, Falso de lo contrario</returns>
        bool VerifyToken(string token);
    }
}
