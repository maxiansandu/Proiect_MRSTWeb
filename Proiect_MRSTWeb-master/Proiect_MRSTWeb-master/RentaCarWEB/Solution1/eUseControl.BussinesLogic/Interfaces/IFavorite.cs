using eUseControl.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUseControl.BussinesLogic.Interfaces
{
    public interface IFavorite
    {

       

         bool ad_to_favorites(Favorite ad);


      //  List<PostTable> my_favorites(string username);

       // bool delete_fav_ad(int ad_id);


    }
}
