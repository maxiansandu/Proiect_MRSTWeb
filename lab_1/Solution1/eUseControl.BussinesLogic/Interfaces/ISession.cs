﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUseControl.BussinesLogic.Interfaces
{
    public interface ISession
    {
        void StratSession(string userId);
        void EndSession();
    }
}
