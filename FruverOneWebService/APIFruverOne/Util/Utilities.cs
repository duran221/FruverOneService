using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIFruverOne.Util
{
    public static class Utilities
    {

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objectModel"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public static JObject BuildResponse<T>(T objectModel,int status)
        {
                return JObject.FromObject(new
                {
                    status = status,
                    data = objectModel
                });
           
        }

    }
}