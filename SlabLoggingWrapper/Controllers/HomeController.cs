using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Damienbod.Slab;

namespace SlabLoggingWrapper.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISlabLogger _logger;

        public HomeController(ISlabLogger logger)
        {
            _logger = logger;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            _logger.Log(GlobalType.GlobalCritical, "Hello World");
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            _logger.Log(WebType.ControllerVerbose, "Hello World");
            return View();
        }
    }
}