using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lab_1_templates_sandu.Controllers
{
    public class LogPageController : Controller
    {
        // GET: LogPage
        public ActionResult UserLogPage()
        {
            return View();
        }
    }
}