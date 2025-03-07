using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using lab_1_templates_sandu.Models;

namespace lab_1_templates_sandu.Controllers
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