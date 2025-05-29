using eUseControl.BussinesLogic;
using eUseControl.BussinesLogic.Core;
using eUseControl.BussinesLogic.Interfaces;
using eUseControl.Domain.Entities.User;
using eUseControl.Helpers.Filters;
using eUseControl.Web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Web;
using System.Web.Mvc;



namespace eUseControl.Web.Controllers
{
    public class AnunceController : Controller
    {

        private readonly IPosts _Posts;



        public AnunceController()
        {

            _Posts = new BL().GetPostsService();

        }

       
        // GET: Anunce
        [SessionValidation]
        public ActionResult eAnunce()
        {

            var api = new UserApi();
            var data = new ULoginData();
            String user = Session["Username"].ToString();

            var anunturi = _Posts.getMyPosts(data,user);

            var viewlist = anunturi.Select(p => new AnunceModel
            {

                id = p.Id,
                img_1 = p.img_1,
                Titlu = p.Title,





            }).ToList();




            return View(viewlist);

           
        }

        [HttpPost]
        public ActionResult AdaugaAnunt(string Titlu, string marca, string model, int an, int motorizare, string fuel, HttpPostedFileBase Imagine_1, HttpPostedFileBase Imagine_2, HttpPostedFileBase Imagine_3, HttpPostedFileBase Imagine_4, HttpPostedFileBase Imagine_5, string Descriere, int Pret, int phone, string Location)
        {

            var anuncebl = new PostTable();

            var anunce = new AnunceModel(

                  );

            anunce.Titlu = Titlu;
            anunce.Marca = marca;
            anunce.model = model;
            anunce.an = an;
            anunce.engine = motorizare;
            anunce.price = Pret;
            anunce.phone = phone;
            anuncebl.fuel = fuel;
            anunce.location = Location;
            anunce.author = Session["Username"]?.ToString();
            anunce.location = Location;
            anunce.description = Descriere;

            if (Imagine_1 != null && Imagine_1.ContentLength > 0)
            {

                string fileName = Path.GetFileNameWithoutExtension(Imagine_1.FileName);
                string extension = Path.GetExtension(Imagine_1.FileName);
                fileName = fileName + "_" + Guid.NewGuid().ToString().Substring(0, 8) + extension;


                string path = Path.Combine(Server.MapPath("~/Content/images/"), fileName);





                Imagine_1.SaveAs(path);


                anunce.img_1 = "/Content/images/" + fileName;
            }
            if (Imagine_2 != null && Imagine_2.ContentLength > 0)
            {

                string fileName = Path.GetFileNameWithoutExtension(Imagine_2.FileName);
                string extension = Path.GetExtension(Imagine_2.FileName);
                fileName = fileName + "_" + Guid.NewGuid().ToString().Substring(0, 8) + extension;


                string path = Path.Combine(Server.MapPath("~/Content/images/"), fileName);





                Imagine_2.SaveAs(path);


                anunce.img_2 = "/Content/images/" + fileName;
            }
            if (Imagine_3 != null && Imagine_3.ContentLength > 0)
            {

                string fileName = Path.GetFileNameWithoutExtension(Imagine_3.FileName);
                string extension = Path.GetExtension(Imagine_3.FileName);
                fileName = fileName + "_" + Guid.NewGuid().ToString().Substring(0, 8) + extension;


                string path = Path.Combine(Server.MapPath("~/Content/images/"), fileName);





                Imagine_3.SaveAs(path);


                anunce.img_3 = "/Content/images/" + fileName;
            }
            if (Imagine_4 != null && Imagine_4.ContentLength > 0)
            {

                string fileName = Path.GetFileNameWithoutExtension(Imagine_4.FileName);
                string extension = Path.GetExtension(Imagine_4.FileName);
                fileName = fileName + "_" + Guid.NewGuid().ToString().Substring(0, 8) + extension;


                string path = Path.Combine(Server.MapPath("~/Content/images/"), fileName);





                Imagine_4.SaveAs(path);


                anunce.img_4 = "/Content/images/" + fileName;
            }
            if (Imagine_5 != null && Imagine_5.ContentLength > 0)
            {

                string fileName = Path.GetFileNameWithoutExtension(Imagine_5.FileName);
                string extension = Path.GetExtension(Imagine_5.FileName);
                fileName = fileName + "_" + Guid.NewGuid().ToString().Substring(0, 8) + extension;


                string path = Path.Combine(Server.MapPath("~/Content/images/"), fileName);





                Imagine_5.SaveAs(path);


                anunce.img_5 = "/Content/images/" + fileName;
            }

            anuncebl.Title = anunce.Titlu;
            anuncebl.Marca = anunce.Marca;
            anuncebl.model = anunce.model;
            anuncebl.an = anunce.an;
            anuncebl.engine = anunce.engine;
            anuncebl.price = anunce.price;
            anuncebl.phone = anunce.phone;
            anuncebl.location = anunce.location;
            anuncebl.author = anunce.author;
            anuncebl.img_1 = anunce.img_1;
            anuncebl.img_2 = anunce.img_2;
            anuncebl.img_3 = anunce.img_3;
            anuncebl.img_4 = anunce.img_4;
            anuncebl.img_5 = anunce.img_5;
            anuncebl.description = anunce.description;


            var api = new UserApi();

            _Posts.adAnunce(anuncebl);




            return Redirect("http://localhost:49932/Anunce/eAnunce");
        }


        [HttpPost]

        public ActionResult DeleteAd(int id)
        {

            var api = new UserApi();

            int user_id = id;

            _Posts.Delete_Post(id);
            return Redirect("http://localhost:49932/Anunce/eAnunce");
        }


       



    }
}