using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUseControl.Domain.Entities.User
{
    [Table("UDBTables")]
    public class UDBTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int id { get; set; }

        [Required]
        [Display(Name = "username")]
      

        public string username { get; set; }

        [Display(Name = "password")]

        public string password { get; set; }

        [Display(Name ="email")]
        public string email { get; set; }
    }
}
