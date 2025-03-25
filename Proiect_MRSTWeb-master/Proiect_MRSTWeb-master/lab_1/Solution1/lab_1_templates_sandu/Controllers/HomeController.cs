using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eUseControl.Web.Models;

namespace eUseControl.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var person = new Person
            {
                specialitatea="TI",
                grupa = 231,
                name = "Sandu"
            };
            return View(person);
        }

       
       

  

    }
}