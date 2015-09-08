using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace QANotes.Models
{
    public class AppPrincipal : ClaimsPrincipal
    {
        public AppPrincipal(ClaimsPrincipal principal)
            : base(principal)
        {

        }
    }
}