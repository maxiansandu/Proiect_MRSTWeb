using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUseControl.Domain.Entities.User
{
    public class UserSession
    {

        public int Id { get; set; }
        public string Username { get; set; }

        public string SessionToken { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ExpiresAt { get; set; }
        public string IpAddress { get; set; }
        public string UserAgent { get; set; }

        //public string Role { get; set; }

    }
}
