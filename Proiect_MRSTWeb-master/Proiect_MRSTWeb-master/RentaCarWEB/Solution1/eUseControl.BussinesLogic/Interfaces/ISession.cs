﻿using eUseControl.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUseControl.BussinesLogic.Interfaces
{
    public interface ISession
    {
        LoginResult LoginUser(ULoginData data);
        RegisterResult RegisterUser(ULoginData data);


        bool SaveSession(UserSession data);

    }
}
