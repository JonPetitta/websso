using api.Cookies;
using api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace api.Controllers
{
    public class AuthController : ApiController
    {
        // GET: api/Auth/identity
        [HttpGet]
        [Route("api/auth/identity")]
        public IHttpActionResult Identity()
        {
            try
            {
                var identity = GetIdentity();
                return Ok(identity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message + " : " + ex.StackTrace);
            }
        }

        private Identity GetIdentity()
        {
            var identity = new Identity();

            var cookie = Request.GetOwinContext()
                                .Request
                                .Cookies[".AspNet.ExternalCookie"];

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
