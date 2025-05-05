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

      

        [HttpPost]
        public ActionResult Login(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Verificăm datele de autentificare
                var loginResult = _session.LoginWithResult(model.username, model.password);
                if (loginResult.Status)
                {
                    
                    Session["Username"] = loginResult.User.username;
                    Session["Email"] = loginResult.User.email;
                    Session["Role"] = loginResult.Role;

                 //   return RedirectToAction("Index", "Home");
                    if (loginResult.Role == "admin")
                        return RedirectToAction("AdminPage", "Cont");
                    else
                        return RedirectToAction("UserPage", "Cont");
                }

                // Dacă autentificarea a eșuat
                ViewBag.Message = loginResult.Message;
                return View("UserLogPage");
            }

           

            // Dacă ModelState nu este valid
            ViewBag.Message = "Datele introduse nu sunt valide.";
            return View("UserLogPage");
        }

        [HttpGet]
        public ActionResult Login2()
        {
            // Verifică dacă datele sunt disponibile în sesiune
            var username = Session["Username"];
            var email = Session["Email"];
            var role = Session["Role"] as string;

            if (role == "admin")
                return RedirectToAction("AdminPage", "Cont");
            else
                return RedirectToAction("UserPage", "Cont");
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
