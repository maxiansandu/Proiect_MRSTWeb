using eUseControl.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUseControl.BussinesLogic.Interfaces
{
    public interface IPosts
    {
        bool adAnunce(PostTable postTable);

         List<PostTable> get_posts();



        List<PostTable> getMyPosts(ULoginData data, string username);

        bool Delete_Post(int ad_id);
    }
}
