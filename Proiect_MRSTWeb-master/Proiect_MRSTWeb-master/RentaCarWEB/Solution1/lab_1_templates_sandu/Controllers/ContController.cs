using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eUseControl.Helpers.Filters;



namespace eUseControl.Web.Controllers
{
   
    public class ContController : Controller
    {
        // GET: Cont
        [SessionValidation]
        public ActionResult UserPage()
        {
            return View();
        }


        [SessionValidation]
        public ActionResult AdminPage()
        {
            return View();
        }


    }
}