using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUseControl.Domain.Entities.User
{
    public class LoginResult
    {
        public bool Status { get; set; }
        public string Message { get; set; }

        public UDBTable User { get; set; }
    }
}
