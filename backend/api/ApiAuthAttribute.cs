using api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace api
{
    public class ApiAuthAttribute : AuthorizeAttribute
    {
        public string Role { get; set; }

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext == null)
            {
                throw new ArgumentNullException("actionContext");
            }

            var identity = Identity.GetIdentity(actionContext.Request);

            if (identity.Roles.Contains(Role))
            {
                return;
            }

            HandleUnauthorizedRequest(actionContext);

            //base.OnAuthorization(actionContext);
        }
    }
}