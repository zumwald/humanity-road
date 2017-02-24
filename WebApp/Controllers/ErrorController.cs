namespace WebApp.Controllers
{
    using System.Web.Mvc;

    [Authorize]
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Index(string message)
        {
            ViewBag.Message = message;
            return View("Error");
        }
    }
}