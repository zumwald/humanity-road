namespace WebApp.Controllers
{
    using System.Web.Mvc;
    using System.Security.Claims;
    using Utilities;
    using DAL;
    using System.Linq;
    using System;

    [RequireHttps(Order = 0)]
    [Authorize(Order = 1)]
    public class AppController : Controller
    {
        private DataContext db = new DataContext();

        public ActionResult Index()
        {
            // if the user has already filled out their information, land them on the timesheet page by default
            // TODO use more official method to validate that user has filled out their info, for now use the skypeId
            var id = ClaimsPrincipal.Current.GetUserProperty(IdentityHelpers.PERSON_ID_K);
            Volunteer volunteer = db.Volunteers.FirstOrDefault(v => v.Id.Equals(id, StringComparison.InvariantCulture));
            if (volunteer != null && !string.IsNullOrWhiteSpace(volunteer.SkypeId))
            {
                Response.SetCookie(new System.Web.HttpCookie("clientStartRoute", "/Home"));
            }

            return View();
        }

        [ActionName("signin-google")]
        public ActionResult SignInGoogle()
        {
            return this.RedirectToAction("Index");
        }

        [ActionName("profile-edit")]
        public ActionResult EditProfile()
        {
            return this.ResolveRouteToIndexIfNeeded() ?? this.View();
        }

        public ActionResult Home()
        {
            return this.ResolveRouteToIndexIfNeeded() ?? this.View();
        }

        private ActionResult ResolveRouteToIndexIfNeeded()
        {
            if (this.Request.Headers["X-Requested-By"] != "AngularClient")
            {
                return RedirectToAction("Index");
            }

            return null;
        }
    }
}