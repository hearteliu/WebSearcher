using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebSearcher.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// The Index iction method
        /// </summary>
        /// <returns>Action result</returns>
        public ActionResult Index()
        {
            return View();
        }
    }
}