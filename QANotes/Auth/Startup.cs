using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using QANotes.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using QANotes.DataAccess;

namespace QANotes.Auth
{
    public class Startup
    {
        public static Func<UserManager<AppUser>> UserManagerFactory { get; private set; }
        public void Configuration(IAppBuilder app)
        {

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Auth/Login")
            });


            UserManagerFactory = () =>
            {
                var userManager = new UserManager<AppUser>(
                    new UserStore<AppUser>(new QANotesContext()));
                // allow alphanumeric characters in username
                userManager.UserValidator = new UserValidator<AppUser>(userManager)
                {
                    AllowOnlyAlphanumericUserNames = false
                };

                return userManager;
            };

        }
    }
}

