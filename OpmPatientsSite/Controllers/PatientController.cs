using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using OpmData;
using OpmInterfaces.Interfaces;
using OpmPatientsSite.Models.Patient;

namespace OpmPatientsSite.Controllers
{
    public class PatientController : Controller
    {
        private readonly IPatientRepository _patientRepository;

        public PatientController(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        // GET: Patient
        public ActionResult CreatePatient()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreatePatient(PatientModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var mapedPatient = Mapper.Map<Patient>(model);
            var patient = _patientRepository.Create(mapedPatient);
            return RedirectToAction("DisplayPatient", new {id = patient.PatientId});
        }

        public ActionResult DisplayPatient(int id = -1)
        {
            if (id <= 0)
                return RedirectToAction("Index", "Home");

            var patient = _patientRepository.GetById(id);
            var patientModel = Mapper.Map<PatientModel>(patient);
            return View(patientModel);
        }
    }
}