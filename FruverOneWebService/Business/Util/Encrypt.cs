using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Business.Util
{
    public static class Encrypt
    {

        /// <summary>
        /// Encripta una cadena de texto con el algoritmo de Cifrado SHA256
        /// </summary>
        /// <param name="password">cadena de texto con la contraseña del usuario a cifrar</param>
        /// <returns>cadena con la contraseña cifrada en SHA256</returns>
        public static string EncryptSHA256(string password)
        {
            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(password));
            for (int i = 0; i < stream.Length; i++)
            {
                sb.AppendFormat("{0:x2}",stream[i]);
            }
            return sb.ToString();

        }
    }
}