using eUseControl.BussinesLogic;
using eUseControl.BussinesLogic.Core;
using eUseControl.BussinesLogic.Interfaces;
using eUseControl.Domain.Entities.User;
using eUseControl.Web.Models;
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

        public ActionResult RegisterPage()
        {
            return View();
        }

        private readonly SessionBL _session = new SessionBL();

        // Afișează pagina de login


        [HttpPost]
        public ActionResult Login(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Verificăm datele de autentificare
                var loginResult = _session.LoginWithResult(model.username, model.password);

                if (loginResult.Status)
                {
                    // Autentificare reușită, redirectăm spre Home
                    return RedirectToAction("Index", "Home");
                }

                // Dacă autentificarea a eșuat
                ViewBag.Message = loginResult.Message;
                return View("UserLogPage");
            }

            // Dacă ModelState nu este valid
            ViewBag.Message = "Datele introduse nu sunt valide.";
            return View("UserLogPage");
        }


        private readonly UserApi _userApi = new UserApi();

        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            if (model.password != model.confirmPassword)
            {
                ViewBag.Message = "Parolele nu se potrivesc.";
                return View(model);
            }

            var userData = new ULoginData
            {
                Username = model.username,
                Password = model.password,
                Email = model.email
            };

            var result = _userApi.RegisterUser(userData);

            if (!result.Status)
            {
                ViewBag.Message = result.Message;
                return View("RegisterPage", model);
            }

            return RedirectToAction("UserLogPage");
        }


    }


}
