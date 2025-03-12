using eUseControl.BussinesLogic.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUseControl.BussinesLogic
{


    public class BussinesLogic
    {
        private readonly UserAPI _userApi;

        public BussinesLogic()
        {
            _userApi = new UserAPI();
        }

        public bool AutjenticateUser(string username, string password)
        {
            return _userApi.Login(username, password);
        }
    }
}
