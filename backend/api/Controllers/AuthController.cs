using api.App_Start;
using api.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace api.Controllers
{
    [ApiAuth(Role = "user")]
    public class AuthController : ApiController
    {
        // GET: api/Auth/identity
        [HttpGet]
        [Route("api/auth/identity")]
        public IHttpActionResult GetIdentity()
        {
            try
            {
                var identity = ApiIdentity.GetIdentity(Request);
                return Ok(identity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message + " : " + ex.StackTrace);
            }
        }

        [HttpGet]
        [Route("api/auth/logout")]
        public IHttpActionResult Logout()
        {
            Request.GetOwinContext()
                .Response
                .Cookies
                .Delete(AppConfig.CookieName,
                        new Microsoft.Owin.CookieOptions());

            return Ok();
        }
    }
}