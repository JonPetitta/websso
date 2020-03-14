using api.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace api.Auth
{
    public class ApiIdentity
    {
        public string LoginId { get; set; }
        public string Name { get; set; }
        public List<string> Roles { get; set; }

        public static ApiIdentity GetIdentity(HttpRequestMessage request)
        {
            var identity = new ApiIdentity();

            var cookie = request.GetOwinContext()
                                .Request
                                .Cookies[AppConfig.CookieName];

            var principal = DecryptCookie.GetClaimsPrincipal(cookie);

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