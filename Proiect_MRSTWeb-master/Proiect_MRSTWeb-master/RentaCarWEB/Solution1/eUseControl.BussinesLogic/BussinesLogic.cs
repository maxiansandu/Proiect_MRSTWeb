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



    }








       
    }
}



