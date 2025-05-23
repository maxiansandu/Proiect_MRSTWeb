using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eUseControl.Domain.Entities.User;


namespace eUseControl.BussinesLogic.DBModel.Seed
{
    public class UserContext : DbContext
    {
        [Key]
        public int Id { get; set; }
        public DbSet<UDBTable> Users { get; set; }

        public DbSet<UserSession> UserSessions { get; set; }

        public DbSet<PostTable> PostTables { get; set; }

        public DbSet<Favorite> Favorites { get; set; }
        public UserContext() : base("name=TWEB") // Folosește numele din connection string
        {
        }
    }
}
