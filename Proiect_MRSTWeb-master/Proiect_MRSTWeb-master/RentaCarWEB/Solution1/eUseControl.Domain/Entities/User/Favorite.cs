using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUseControl.Domain.Entities.User
{
    public class Favorite
    {
        [Key] // Cheia primară
        public int Id { get; set; }

        public int ad_id {  get; set; }

       public string author { get; set; }
    

       

      

      


    }
}
