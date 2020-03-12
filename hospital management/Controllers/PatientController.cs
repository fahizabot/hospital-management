using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace hospital_management.Controllers
{
    public class PatientController : Controller
    {
        // GET: Patient
        public ActionResult NewPatient()
        {
            return View();
        }

        public ActionResult PatientHomepage()
        {
            return View();
        }
        public ActionResult PatientDashboard()
        {
            return View();
        }
        public ActionResult Speciality()
        {
            return View();
        }
        public ActionResult HospitalDetails()
        {
            return View();
        }
        public ActionResult ChooseDoctor()
        {
            return View();
        }

        public ActionResult Appointment()
        {
            return View();
        }

    }
}