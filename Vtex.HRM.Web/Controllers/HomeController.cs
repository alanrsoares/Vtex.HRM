using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Vtex.HRM.Web.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {

            var client = new WebClient
                             {
                                 Credentials = new NetworkCredential("alertawebstore@vtex.com.br", "vtexonline1")
                             };

            client.Headers.Add("app-key", "8gofngoojyhtc16t4q0b1sflrt2czq4b");

            var response = client.DownloadString(new Uri("https://api.pingdom.com/api/2.0/checks/"));

            ViewBag.ServiceResponse = response;

            return View(ViewBag);
        }

    }
}
