using api.Cookies;
using api.Models;
using api.Utils;
using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using Newtonsoft.Json;
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
        [HttpGet]
        [Route("api/auth/token")]
        public IHttpActionResult Token()
        {
            try
            {
                var token = GetToken();
                return Ok(token);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message + " : " + ex.StackTrace);
            }
        }

        private string GetToken()
        {
            var identity = GetIdentity();

            var expiresIn = DateTimeOffset.UtcNow
                .AddMinutes(30)
                .ToUnixTimeSeconds();

            var payload = new Dictionary<string, object>
            {
                { "exp", expiresIn },
                { "identity", identity }
            };

            IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
            var jsonSerializer = new JsonSerializer()
            {
                ContractResolver = new CamelCaseContractResolver()
            };
            IJsonSerializer serializer = new JsonNetSerializer(jsonSerializer);
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);

            var token = encoder.Encode(payload, "mysecret");

            return token;
        }

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
