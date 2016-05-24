using System.Configuration;
using System.Security.Claims;
using Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Google;

namespace WebApp
{
    public partial class Startup
    {
        private static readonly string GoogleClientId = ConfigurationManager.AppSettings["google:ClientId"];
        private static readonly string GoogleClientSecret = ConfigurationManager.AppSettings["google:Secret"];

        public void ConfigureAuth(IAppBuilder app)
        {
            app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);

            app.UseCookieAuthentication(new CookieAuthenticationOptions());

            app.UseGoogleAuthentication(
                new GoogleOAuth2AuthenticationOptions()
                {
                    ClientId = GoogleClientId,
                    ClientSecret = GoogleClientSecret,
                    AuthenticationMode = AuthenticationMode.Active,
                    Provider = new GoogleOAuth2AuthenticationProvider()
                    {
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
                        OnAuthenticated = async context =>
                        {
                            var user = context.User.Root;
                            context.Identity.AddClaim(new Claim(Utilities.IdentityHelpers.IMAGE_URI_K, user["image"]?["url"]?.ToString()));
                            context.Identity.AddClaim(new Claim(Utilities.IdentityHelpers.PERSON_ID_K, $"{user["id"]?.ToString()}:{user["emails"]?.First?["value"]?.ToString()}"));
                            context.Identity.AddClaim(new Claim(Utilities.IdentityHelpers.PERSON_FIRSTNAME_K, user["name"]?["givenName"]?.ToString()));
                            context.Identity.AddClaim(new Claim(Utilities.IdentityHelpers.PERSON_LASTNAME_K, user["name"]?["familyName"]?.ToString()));
                            context.Identity.AddClaim(new Claim(Utilities.IdentityHelpers.PERSON_PRIMARY_EMAIL_K, user["emails"]?.First?["value"]?.ToString()));
                        }
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
                    }
                });
        }
    }
}