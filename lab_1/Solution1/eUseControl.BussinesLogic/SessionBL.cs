using eUseControl.BussinesLogic.Core;
using eUseControl.BussinesLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUseControl.BussinesLogic
{  
   public class SessionBL : UserAPI, ISession
    {
        public void StartSession(string userId)
        {
            Console.WriteLine($"susiunea a fost inceputa pentru utilizatorul {userId}");
        }

        public void EndSession()
        {
            Console.WriteLine("Sesiunea a fost inchisa");
        }
    }
}
