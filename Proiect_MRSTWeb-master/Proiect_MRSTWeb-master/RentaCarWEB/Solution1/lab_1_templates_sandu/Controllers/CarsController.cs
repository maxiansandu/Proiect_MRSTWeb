using eUseControl.BussinesLogic.Core;
using eUseControl.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eUseControl.Web.Controllers
{
    public class CarsController : Controller
    {
        // GET: Cars
        public ActionResult eCars()
        {
            var api = new UserApi();
            var carLiast = api.get_posts();
            
           var viewlist = carLiast.Select(p => new AnunceModel
            {

                id=p.Id,
                img_1= p.img_1,
                Titlu=p.Title,
              
                



            }).ToList();
                

             

            return View(viewlist);
        }

        public ActionResult Details(int id)
        {


            var api = new UserApi();
            var post = api.get_posts().FirstOrDefault(p => p.Id == id);




            var viewpost = new AnunceModel
            {

                Titlu = post.Title,
                img_1 = post.img_1,
                img_2 = post.img_2,
                img_3 = post.img_3,
                img_4 = post.img_4,
                img_5 = post.img_5,
                Marca = post.Marca,
                model = post.model,
                an = post.an,
                engine = post.engine,
                fuel = post.fuel,
                price = post.price,
                description = post.description,
                author=post.author,
                phone=post.phone,
                location = post.location





            };






            return View(viewpost);



        }

    }
}