using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OpmInterfaces.Interfaces;
using OpmPatientsSite.Models.Login;

namespace OpmPatientsSite.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly ISessionManagementService _sessionManagement;

        public LoginController(IUserRepository userRepository, ISessionManagementService sessionManagement)
        {
            _userRepository = userRepository;
            _sessionManagement = sessionManagement;
        }

        public ActionResult Index()
        {
            return View("Login");
        }

        [HttpPost]
        public ActionResult Login(LoginModel user)
        {
            if (_sessionManagement.LogIn(user.Username, user.Password))
                return RedirectToAction("Index", "Home");

            return View();
        }

        public ActionResult Logout()
        {
            _sessionManagement.LogOut();
            return RedirectToAction("Index");
        }
    }
}