using eUseControl.BussinesLogic.Core;
using eUseControl.BussinesLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUseControl.BussinesLogic
{


    public class BussinesLogic
    {
      public ISession GetSessionBl()
        {
            return new SessionBL();
        }

    }
}
