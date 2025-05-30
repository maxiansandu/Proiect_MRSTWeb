using eUseControl.BussinesLogic;
using eUseControl.BussinesLogic.Core;
using eUseControl.BussinesLogic.Interfaces;
using eUseControl.Domain.Entities.User;
using eUseControl.Web.Models;
using System.Web;
using System;
using System.Web.Mvc;
using eUseControl.BussinesLogic.DBModel.Seed;
using System.Linq;



namespace eUseControl.Web.Controllers
{
   
    public class LogPageController : Controller
    {

        private readonly ISession _session;

        public LogPageController()
        {
            _session = new BL().GetSession();
        }
        // GET: Login
        public ActionResult UserLogPage()
        {
            return View();
        }

        public ActionResult RegisterPage()
        {
            return View();
        }

      

        
        [HttpPost]
        
        public ActionResult Login(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var loginResult =new LoginResult();
                var data =new ULoginData();
                data.Username = model.username;
                data.Password =model.password;
                
                loginResult = _session.LoginUser(data);
                if (loginResult.Status)
                {
                    Session["Username"] = loginResult.User.username;
                    Session["Email"] = loginResult.User.email;
                    Session["Role"] = loginResult.Role;

                    var token = Guid.NewGuid().ToString();
                    var newSession = new UserSession
                    {
                        Username = loginResult.User.username,
                        SessionToken = token,
                        IpAddress = Request.UserHostAddress,
                        UserAgent = Request.UserAgent,
                        CreatedAt = DateTime.Now,
                        ExpiresAt = DateTime.Now.AddMinutes(30)  // Setează timpul de expirare pentru sesiune
                    };

                    _session.SaveSession(newSession);
                   

                    var cookie = new HttpCookie("AuthToken", token)
                    {
                        Expires = DateTime.Now.AddMinutes(30) // Setează expirarea cookie-ului
                    };
                    Response.Cookies.Add(cookie);

                    if (loginResult.Role == "admin")
                        return RedirectToAction("AdminPage", "Cont");
                    else
                        return RedirectToAction("UserPage", "Cont");
                }

                ViewBag.Message = loginResult.Message;
                return View("UserLogPage");
            }

            ViewBag.Message = "Datele introduse nu sunt valide.";
            return View("UserLogPage");
        }

        [HttpGet]
       

        public ActionResult Login2()
        {
          
               
                   
                      
            var role = Session["Role"] as string;
            
            if (role == "admin") {
                return RedirectToAction("AdminPage", "Cont");
            }
            else { 
                return RedirectToAction("UserPage", "Cont");
                    }
        
                
            

            
        }










        [HttpPost]
        public ActionResult Logout()
        {
            var token = Request.Cookies["AuthToken"]?.Value;

            if (!string.IsNullOrEmpty(token))
            {
                using (var db = new UserContext())
                {
                    var session = db.UserSessions.FirstOrDefault(s => s.SessionToken == token);
                    if (session != null)
                    {
                        db.UserSessions.Remove(session);
                        db.SaveChanges();
                    }
                }

                
                var cookie = new HttpCookie("AuthToken")
                {
                    Expires = DateTime.Now.AddDays(-1)
                };
                Response.Cookies.Add(cookie);
            }

            return RedirectToAction("Login2");
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



            
           var result = _session.RegisterUser(userData);

            if (!result.Status)
            {
                ViewBag.Message = result.Message;
                return View("RegisterPage", model);
            }

            return RedirectToAction("UserLogPage");
        }


    }


}
