using System;
using System.Linq;
using System.Web;

using eUseControl.Domain.Entities.User;
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
                filterContext.Result = new RedirectResult("/LogPage/UserLogPage");
                return;
            }

            using (var db = new UserContext()) // sau YourDbContext
            {
                var session = db.UserSessions.FirstOrDefault(s => s.SessionToken == token);

                if (session == null || session.IpAddress != filterContext.HttpContext.Request.UserHostAddress)
                {
                    filterContext.Result = new RedirectResult("/LogPage/UserLogPage");
                    return;
                }
            }

            base.OnActionExecuting(filterContext);
        }
    }
}