﻿
using eUseControl.BussinesLogic.Core;
using eUseControl.BussinesLogic.Interfaces;
using eUseControl.Domain.Entities.User;
using eUseControl.Helpers.Filters;
using eUseControl.Web.Models;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using eUseControl.BussinesLogic;

namespace eUseControl.Web.Controllers
{
    public class FavoritesController : Controller
    {

        private readonly IFavorite _FavoriteService;

        public FavoritesController()
        {
            _FavoriteService = new BL().GetFavoriteService();
        }
        // GET: Favorites
        [SessionValidation]
        public ActionResult FavoritPage()
        {

            string username = Session["username"].ToString();
            var api = new UserApi();

            var view_fav = _FavoriteService.my_favorites(username);

            if (view_fav == null){

                ViewBag.Message = "Momentan nu aveți anunțuri salvate la favorite.";
                return View(new List<AnunceModel>());


            }
            else
            {

                var view_modell = view_fav.Select(p => new AnunceModel
                {

                    id = p.Id,
                    img_1 = p.img_1,
                    Titlu = p.Title,





                }).ToList();
                return View("FavoritPage", view_modell);


            }

           
        }

        [HttpPost]


        public ActionResult Save_to_favorite(int id) {




            var ad_fav = new Favorite_ad();

            ad_fav.id = id;

             var fav_ad = new Favorite();

            fav_ad.ad_id = ad_fav.id;
            fav_ad.author = Session["username"].ToString();


         

            


      


            _FavoriteService.ad_to_favorites(fav_ad);



            return Redirect(Request.UrlReferrer.ToString());



        }

        [HttpPost]


        public ActionResult DeleteFavorite(int id) { 



            var api = new UserApi();
            

            _FavoriteService.delete_fav_ad(id);





            return Redirect(Request.UrlReferrer.ToString());





        }





    }
}