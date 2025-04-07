using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUseControl.BussinesLogic.Interfaces
{
    public interface ISession
    {
        bool Login(string username, string password);
        
    }
}
