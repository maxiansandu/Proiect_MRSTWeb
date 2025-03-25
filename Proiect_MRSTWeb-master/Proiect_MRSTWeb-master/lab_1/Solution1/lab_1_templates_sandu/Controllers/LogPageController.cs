﻿using eUseControl.BussinesLogic;
using eUseControl.BussinesLogic.Core;
using eUseControl.BussinesLogic.Interfaces;
using eUseControl.Domain.Entities.User;
using System.Web.Mvc;

namespace eUseControl.Web.Controllers
{
    public class LogPageController : Controller
    {
        // GET: Login
        public ActionResult UserLogPage()
        {
            return View();
        }

        private readonly SessionBL _session = new SessionBL();

        // Afișează pagina de login


        // Procesează datele introduse de utilizator
        [HttpPost]
        public ActionResult Login(ULoginData user)
        {
            // Verify user credentials
            bool isValidUser = _session.Login(user.Username, user.Password);

            if (isValidUser)
            {
                return RedirectToAction("Index", "Home"); // Redirects to the HomePage action in the Home controller // Redirect to the dashboard
            }

            // If authentication fails
            ViewBag.Message = "Invalid credentials";
            return View("UserLogPage");
        }
    }
}
