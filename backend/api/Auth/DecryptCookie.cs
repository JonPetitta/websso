using api.App_Start;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace api.Auth
{
    public class DecryptCookie
    {
        //taken from here
        //https://gist.github.com/zzquilt/2108e99232a9b4a7b4de49ea2292305d
        public static ClaimsPrincipal GetClaimsPrincipal(string cookie)
        {
            cookie = cookie.Replace('-', '+').Replace('_', '/');

            var padding = 3 - ((cookie.Length + 3) % 4);
            if (padding != 0)
                cookie = cookie + new string('=', padding);

            var bytes = Convert.FromBase64String(cookie);

            bytes = System.Web.Security.MachineKey.Unprotect(bytes,
                "Microsoft.Owin.Security.Cookies.CookieAuthenticationMiddleware",
                AppConfig.AuthenticationType,
                "v1");

            using (var memory = new MemoryStream(bytes))
            {
                using (var compression = new GZipStream(memory,
                                                    CompressionMode.Decompress))
                {
                    using (var reader = new BinaryReader(compression))
                    {
                        reader.ReadInt32();
                        string authenticationType = reader.ReadString();
                        reader.ReadString();
                        reader.ReadString();

                        int count = reader.ReadInt32();

                        var claims = new Claim[count];
                        for (int index = 0; index != count; ++index)
                        {
                            string type = reader.ReadString();
                            type = type == "\0" ? ClaimTypes.Name : type;

                            string value = reader.ReadString();

                            string valueType = reader.ReadString();
                            valueType = valueType == "\0" ?
                                           "http://www.w3.org/2001/XMLSchema#string" :
                                             valueType;

                            string issuer = reader.ReadString();
                            issuer = issuer == "\0" ? "LOCAL AUTHORITY" : issuer;

                            string originalIssuer = reader.ReadString();
                            originalIssuer = originalIssuer == "\0" ?
                                                         issuer : originalIssuer;

                            claims[index] = new Claim(type, value,
                                                   valueType, issuer, originalIssuer);
                        }

                        var identity = new ClaimsIdentity(claims, authenticationType,
                                                      ClaimTypes.Name, ClaimTypes.Role);

                        var principal = new ClaimsPrincipal(identity);

                        return principal;
                    }
                }
            }
        }
    }
}