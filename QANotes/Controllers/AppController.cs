using QANotes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace QANotes.Controllers
{
    public abstract class AppController : Controller
    {
        public AppPrincipal CurrentUser
        {
            get
            {
                return new AppPrincipal(User as ClaimsPrincipal);
            }
        }
    }
}