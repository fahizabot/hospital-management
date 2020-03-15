using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer;
using DataAccessLayer.model;

namespace hospital_management.Controllers
{
    public class PatientController : Controller
    {
        // GET: Patient
        public ActionResult NewPatient()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewPatient(newpatient model)
        {
            dataaccess_class dac = new dataaccess_class();
            dac.patientdetails(model.UserName, model.Mail, model.MobileNumber, model.Address, model.PassWord);
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