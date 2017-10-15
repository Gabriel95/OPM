using System.Web.Mvc;
using OpmPatientsSite.Models.Record;

namespace OpmPatientsSite.Controllers
{
    public class RecordController : Controller
    {
        // GET: Record
        public ActionResult Index()
        {
            return RedirectToAction("Index","Home");
        }

        [HttpPost]
        public ActionResult AddRecordView(int patientId = -1)
        {
            if (patientId <= 0)
                return RedirectToAction("Index", "Home");
            var model = new NewRecordModel{ PatientId = patientId};
            return View("AddRecord", model);
        }

        [HttpPost]
        public ActionResult AddRecord(NewRecordModel model)
        {
            return RedirectToAction("Index");
        }
    }
}