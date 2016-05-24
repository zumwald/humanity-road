using System.Web.Mvc;

namespace WebApp.Controllers
{
    [RequireHttps(Order = 0)]
    [Authorize(Order = 1)]
    public class AppController : Controller
    {
        public ActionResult Index()
        {
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