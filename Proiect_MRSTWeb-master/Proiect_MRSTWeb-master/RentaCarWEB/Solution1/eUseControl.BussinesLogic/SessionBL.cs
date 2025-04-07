using eUseControl.BussinesLogic.Core;
using eUseControl.BussinesLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUseControl.BussinesLogic
{
    public class SessionBL : ISession
    {
        private readonly string validUsername = "admin";
        private readonly string validPassword = "1234";

        public bool Login(string username, string password)
        {
            return username == validUsername && password == validPassword;


        }
    }
}

