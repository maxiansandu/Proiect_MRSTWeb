using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eUseControl.Web.Controllers
{
    public class ContController : Controller
    {
        // GET: Cont
        public ActionResult UserPage()
        {
            return View();
        }

        public ActionResult AdminPage()
        {
            return View();
        }
    }
}