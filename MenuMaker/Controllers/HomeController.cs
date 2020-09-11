using System.Web.Mvc;

namespace MenuMaker.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {

        }

        public ActionResult Index()
        {
            return View();
        }
    }
}