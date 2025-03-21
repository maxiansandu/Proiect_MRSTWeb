using eUseControl.BussinesLogic;
using eUseControl.BussinesLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace lab_1_templates_sandu.Controllers
{
    public class LogPageController : Controller
    {
<<<<<<< HEAD

        private readonly ISession _session;

        public LogPageController()
        {

            var bLogic = new BussinesLogic();
            _session = bLogic.GetSessionBl();
        }


        // GET: LogPage
=======
        private readonly ISession
            public LogPageController()
        {
            var bl = new BussinesLogic();
            _session = bl.GetSessionBL();
        }

        //GET: Login
>>>>>>> e90d2d819e7fde7d5caf3776bd54ea2a58fe53be
        public ActionResult UserLogPage()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Index(UserLogin login)
        {
            if (ModelState.IsValid) {
                ULoginData data = new ULoginData
                {
                    CredentialCache = login.Credential,
                    Password = login.Password,
                    LoginIp = Request.UserHostAddress,
                    LoginDateTime = DateTime.Now
                };
                var userLogin = _session.UserLogin(data);
                if (userLogin.Status)
                {
                    //Add COOKIE

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", userLogin.StatusMsg);
                    return View();
                }
        }
            return View();
    }
}