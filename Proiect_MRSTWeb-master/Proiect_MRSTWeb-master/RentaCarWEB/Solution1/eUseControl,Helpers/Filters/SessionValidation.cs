using System;
using System.Linq;

using eUseControl.BussinesLogic.DBModel.Seed;
using System.Web.Mvc; // unde ai UserContext



namespace eUseControl.Helpers.Filters
{


        public class SessionValidationAttribute : ActionFilterAttribute
        {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var token = filterContext.HttpContext.Request.Cookies["AuthToken"]?.Value;

            if (string.IsNullOrEmpty(token))
            {
                // Dacă nu există token în cookie, redirecționează la login
                filterContext.Result = new RedirectResult("/LogPage/UserLogPage");
                return;
            }

            using (var db = new UserContext())
            {
                var session = db.UserSessions.FirstOrDefault(s => s.SessionToken == token);

                if (session == null || session.IpAddress != filterContext.HttpContext.Request.UserHostAddress ||  session.ExpiresAt < DateTime.Now)
            {
                        // Dacă sesiunea nu există sau a expirat, redirecționează la login
                        if (session != null)
                        {
                            db.UserSessions.Remove(session);
                            db.SaveChanges();
                        }
                        filterContext.Result = new RedirectResult("/LogPage/UserLogPage");
                        return;
                    }
                

            
                var user = db.Users.FirstOrDefault(u => u.username == session.Username);
                if (user != null)
                {
                    var httpSession = filterContext.HttpContext.Session;
                    httpSession["Username"] = user.username;
                    httpSession["Email"] = user.email;

                    if (user.password == "admin")
                    {
                        httpSession["Role"] = "admin";

                    }
                    else
                    {
                        httpSession["Role"] = "user";

                    }

                  

                }

            }
           

            // Dacă sesiunea este validă, continuă execuția acțiunii
            base.OnActionExecuting(filterContext);
            }
        }
    }
   
