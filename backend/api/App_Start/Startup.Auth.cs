using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Owin;
using Sustainsys.Saml2;
using Sustainsys.Saml2.Configuration;
using Sustainsys.Saml2.Metadata;
using Sustainsys.Saml2.Owin;
using System;
using System.Configuration;

namespace api.App_Start
{
    public static class AppConfig
    {
        public static readonly string AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie;
        public static readonly string CookieName = ".AspNet.ApplicationCookie";
    }

    public partial class Startup
    {
        // For more information on configuring authentication, 
        // please visit http://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            var cookieOptions = new CookieAuthenticationOptions
            {
                AuthenticationType = AppConfig.AuthenticationType
            };

            app.UseCookieAuthentication(cookieOptions);

            app.SetDefaultSignInAsAuthenticationType(cookieOptions.AuthenticationType);

            app.UseSaml2Authentication(CreateSaml2Options());
        }

        private static Saml2AuthenticationOptions CreateSaml2Options()
        {
            var entiyId = ConfigurationManager.AppSettings["saml:BackendAuthUrl"];
            var returnUrl = ConfigurationManager.AppSettings["saml:FrontendAuthUrl"];
            var spOptions = new SPOptions()
            {
                EntityId = new EntityId(entiyId),
                ReturnUrl = new Uri(returnUrl)
            };

            var saml2Options = new Saml2AuthenticationOptions(false)
            {
                SPOptions = spOptions,
                // can tie into pipeline here
                // uncomment to see saml working
                Notifications = new Saml2Notifications()
                {
                    AuthenticationRequestCreated = (request, rIdp, parms) =>
                    {
                        var test = parms;
                    },
                    AcsCommandResultCreated = (commandResult, response) =>
                    {
                        var test = commandResult.Principal.Claims;
                    }
                }
            };

            var ipEntityId = ConfigurationManager.AppSettings["saml:IPEntityId"];
            var ipMetadata = ConfigurationManager.AppSettings["saml:IPMetadataUrl"];
            var idp = new IdentityProvider(new EntityId(ipEntityId), spOptions)
            {
                //enable idp initiated signin
                AllowUnsolicitedAuthnResponse = true,
                MetadataLocation = ipMetadata
            };

            saml2Options.IdentityProviders.Add(idp);

            return saml2Options;
        }
    }
}