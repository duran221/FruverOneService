﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(APIFruverOne.Startup))]

namespace APIFruverOne
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

        }
        
    }

}
