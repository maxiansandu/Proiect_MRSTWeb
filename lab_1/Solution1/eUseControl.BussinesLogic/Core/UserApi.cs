using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUseControl.BussinesLogic.Core
{
    public class UserAPI
    {

        public bool Login(string username, string password)
        {

            return username == "admin" && password == "1234";
        }
    }
}
