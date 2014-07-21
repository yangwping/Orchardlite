using Orchard.Themes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace hello.Controllers
{
    [Themed]
    public class MyTestController : Controller
    {
        //
        // GET: /MyTest/

        public ActionResult Index()
        {
            return View();
        }
	}
}