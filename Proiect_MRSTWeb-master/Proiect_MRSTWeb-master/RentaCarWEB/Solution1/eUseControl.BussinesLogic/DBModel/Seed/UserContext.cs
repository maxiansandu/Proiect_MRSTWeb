using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eUseControl.Domain.Entities.User;


namespace eUseControl.BussinesLogic.DBModel.Seed
{
    internal class UserContext:DbContext
    {
        public UserContext()
        : base("name=TWEB") // ia connection string-ul din web.config
        {
        }

        public virtual DbSet<UDBTable> Users { get; set; }

    }
}
