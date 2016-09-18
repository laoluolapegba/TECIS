using System.Web.Mvc;

namespace TECIS.Web.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error

        public ViewResult Index()
        {
            return View("Error");
        }
        public ViewResult NotFoundError()
        {
            Response.StatusCode = 404;  //you may want to set this to 200
            return View("NotFoundError");
        }
        public ViewResult InternalServerError()
        {
            Response.StatusCode = 500;
            return View("InternalServerError");
        }
        public ActionResult UnAuthorized()
        {
            return View();
        }
    }
}