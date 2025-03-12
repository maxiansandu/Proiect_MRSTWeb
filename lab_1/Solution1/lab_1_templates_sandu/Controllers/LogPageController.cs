using eUseControl.BussinesLogic;
using eUseControl.BussinesLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lab_1_templates_sandu.Controllers
{
    public class LogPageController : Controller
    {

        private readonly ISession _session;

        public LogPageController()
        {

            var bLogic = new BussinesLogic();
            _session = bLogic.GetSessionBl();
        }


        // GET: LogPage
        public ActionResult UserLogPage()
        {
            return View();
        }
    }
}