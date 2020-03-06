using api.App_Start;
using api.Cookies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace api.Models
{
    public class Identity
    {
        public string LoginId { get; set; }
        public string Name { get; set; }
        public List<string> Roles { get; set; }

        public static Identity GetIdentity(HttpRequestMessage request)
        {
            var identity = new Identity();

            var cookie = request.GetOwinContext()
                                .Request
                                .Cookies[AppConfig.AuthenticationType];

            var principal = DecryptOwinCookie.GetClaimsPrincipal(cookie);

            var name = principal.Claims
                .Where(c => c.Type.Contains("identity/claims/nameidentifier"))
                .Select(v => v.Value)
                .FirstOrDefault();
            var roles = principal.Claims
                .Where(c => c.Type.Contains("role"))
                .Select(v => v.Value)
                .ToList();

            identity.Name = name;
            identity.LoginId = name;
            identity.Roles = roles;

            return identity;
        }
    }
}