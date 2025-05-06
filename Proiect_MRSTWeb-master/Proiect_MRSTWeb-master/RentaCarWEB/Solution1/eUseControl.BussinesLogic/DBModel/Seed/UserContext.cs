using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eUseControl.Domain.Entities.User;


namespace eUseControl.BussinesLogic.DBModel.Seed
{
    public class UserContext : DbContext
    {
        public DbSet<UDBTable> Users { get; set; }

        public DbSet<UserSession> UserSessions { get; set; }

        public UserContext() : base("name=TWEB") // Folosește numele din connection string
        {
        }
    }
}
