using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OpmInterfaces.Interfaces;

namespace OpmPatientsSite.Controllers
{
    public class HomeController : Controller
    {

        private readonly ISessionManagementService _sessionManagement;

        public HomeController(ISessionManagementService sessionManagement)
        {
            _sessionManagement = sessionManagement;
        }

        public ActionResult Index()
        {
            var id = _sessionManagement.GetUserLoggedId();
            if (id == "")
                return RedirectToAction("Index", "Login");

            ViewBag.DoctorName = _sessionManagement.GetUserLoggedName();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}