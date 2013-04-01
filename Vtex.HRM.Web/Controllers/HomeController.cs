using System.Web.Mvc;
using Pingdom.Client;

namespace Vtex.HRM.Web.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            ViewBag.ServiceResponse = new PingdomClient().Resources.Checks.GetChecksList();

            return View(ViewBag);
        }
    }
}
