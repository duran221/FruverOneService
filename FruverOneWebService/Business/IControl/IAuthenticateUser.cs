using Domain.Class;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.IControl
{
    public interface IAuthenticateUser
    {
        UserAccount Login(JObject userCredentials);
    }
}
