using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpmInterfaces.Interfaces
{
    public interface ISessionManagementService
    {
        bool LogIn(string userName, string password);
        void LogOut();
        string GetUserLoggedName();
        string GetUserLoggedUsername();
        string GetUserLoggedRole();
        string GetUserLoggedId();
    }
}
