using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using OpmData.Entities;
using OpmInterfaces.Interfaces;

namespace OpmImplement.Services
{
    public class SessionManagementService : ISessionManagementService
    {
        private readonly IUserRepository _userRepository;
        private readonly string _userNameIdentifier;
        private readonly string _userRoleIdentifier;
        private readonly string _userEmailIdentifier;
        private readonly string _userIdIdentifier;

        public SessionManagementService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _userNameIdentifier = "loggedUserName";
            _userEmailIdentifier = "loggedUserEmail";
            _userRoleIdentifier = "loggedUserRole";
            _userIdIdentifier = "loggedUserId";
        }

        public bool LogIn(string userName, string password)
        {
            var user = _userRepository.Filter(x => x.Username.Equals(userName)).FirstOrDefault();
            if (user == null)
                return false;
            if (!user.Password.Equals(password))
                return false;
            UpdateSessionFromUser(user);
            return true;
        }

        private void UpdateSessionFromUser(User user)
        {
            HttpContext.Current.Session[_userEmailIdentifier] = user.Username;
            HttpContext.Current.Session[_userNameIdentifier] = user.FirstName + " " + user.LastName;
            HttpContext.Current.Session[_userRoleIdentifier] = user.Role;
            HttpContext.Current.Session[_userIdIdentifier] = user.UserId;
        }

        public void LogOut()
        {
            HttpContext.Current.Session.Remove(_userEmailIdentifier);
            HttpContext.Current.Session.Remove(_userNameIdentifier);
            HttpContext.Current.Session.Remove(_userRoleIdentifier);
            HttpContext.Current.Session.Remove(_userIdIdentifier);
        }

        public string GetUserLoggedName()
        {
            var userName = HttpContext.Current.Session[_userNameIdentifier];
            return userName?.ToString() ?? "";
        }

        public string GetUserLoggedUsername()
        {
            var userName = HttpContext.Current.Session[_userEmailIdentifier];
            return userName?.ToString() ?? "";
        }

        public string GetUserLoggedRole()
        {
            var userRole = (Role)HttpContext.Current.Session[_userRoleIdentifier];
            return userRole?.Description ?? "";
        }

        public string GetUserLoggedId()
        {
            var userId = HttpContext.Current.Session[_userIdIdentifier];
            return userId?.ToString() ?? "";
        }
    }
}
