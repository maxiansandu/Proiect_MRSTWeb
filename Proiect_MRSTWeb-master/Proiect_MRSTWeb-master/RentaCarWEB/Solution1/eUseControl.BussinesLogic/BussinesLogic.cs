using eUseControl.BussinesLogic.Core;
using eUseControl.BussinesLogic.Interfaces;
using eUseControl.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace eUseControl.BussinesLogic
{
    public class BL
    {

        public IFavorite GetFavoriteService()
        {

            return new FavoriteBL();
        }


        public class FavoriteBL : UserApi , IFavorite {


            public bool ad_to_favorites(Favorite ad)
        {

            return  ad_to_favorites_action( ad);
        }

            public List<PostTable> my_favorites(string username)
            {

                return my_favorites_action( username);
            }


            public bool delete_fav_ad(int ad_id)
            {


                return delete_fav_ad_action( ad_id);
            }
        }


        public IPosts GetPostsService()
        {

            return new PostsBL();
        }


        public class PostsBL: UserApi , IPosts {

            public bool adAnunce(PostTable postTable)
            {
                return adAnunce_action( postTable);
            }

            public List<PostTable> get_posts()
            {

                return get_posts_action();
            }

            public List<PostTable> getMyPosts(ULoginData data, string username)
            {

                return getMyPosts_action(data, username);
            }


            public bool Delete_Post(int ad_id)
            {

                return Delete_Post_action( ad_id);
            }
        }


        public ISession GetSession()
        {

            return new SessionBL();
        }

        public class SessionBL : UserApi, ISession {


            public LoginResult LoginUser(ULoginData data)
            {

                return LoginUser_action( data);
            }

            public RegisterResult RegisterUser(ULoginData data)
            {
                return RegisterUser_action( data);
            }

            public bool SaveSession(UserSession data)
            {

                return SaveSession_action( data);
            }

        }

       
    }
}



