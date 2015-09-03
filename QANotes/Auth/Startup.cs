using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QANotes.Auth
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions {
                AuthenticationType = "ApplicationCookie",

                // TODO Set this to login controller, login action
                LoginPath = new PathString("/auth/login")
            });
        }
    }
}