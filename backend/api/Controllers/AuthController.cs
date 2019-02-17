using api.Cookies;
using api.Models;
using api.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
                var identity = Identity.GetIdentity(Request);
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
                .Delete(".AspNet.ExternalCookie",
                        new Microsoft.Owin.CookieOptions());

            return Ok();
        }
    }
}
