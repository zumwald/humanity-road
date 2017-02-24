namespace WebApp.Controllers
{
    using System.Security.Claims;
    using System.Web.Http;
    using System.Web.Mvc;
    using WebApp.Utilities;

    [RequireHttps(Order = 0)]
    [System.Web.Mvc.Authorize(Order = 1)]
    public class AccountController : ApiController
    {
        // GET /api/account
        public object Get()
        {
            return new
            {
                firstName = ClaimsPrincipal.Current.GetUserProperty(IdentityHelpers.PERSON_FIRSTNAME_K),
                lastName = ClaimsPrincipal.Current.GetUserProperty(IdentityHelpers.PERSON_LASTNAME_K),
                primaryEmail = ClaimsPrincipal.Current.GetUserProperty(IdentityHelpers.PERSON_PRIMARY_EMAIL_K),
                id = ClaimsPrincipal.Current.GetUserProperty(IdentityHelpers.PERSON_ID_K),
                imageUri = ClaimsPrincipal.Current.GetUserProperty(IdentityHelpers.IMAGE_URI_K)
            };
        }
    }
}