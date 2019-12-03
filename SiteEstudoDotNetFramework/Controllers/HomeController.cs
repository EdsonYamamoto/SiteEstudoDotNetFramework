using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SiteEstudoDotNetFramework.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            Console.WriteLine("teste");

            return View();
        }

        // GET: Login
        public ActionResult Login()
        {
            return View();
        }


        //GET: Logged
        [Authorize(Roles = "SuperAdmin, Admin, User")]
        public ActionResult Logged()
        {
            return View();
        }
    }
}
