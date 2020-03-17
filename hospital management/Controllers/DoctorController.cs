using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer;
using DataAccessLayer.model;

namespace hospital_management.Controllers
{
    public class DoctorController : Controller
    {
        // GET: Doctor
        public ActionResult NewDoctor()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewDoctor(newdoctor model)
        {
            dataaccess_class dac = new dataaccess_class();
           
            dac.doctordetails(model.UserName,model.Mail,model.MobileNumber,model.Address,model.HospitalName,model.SpecialistName,model.Experience,model.Fees,model.PassWord);
            return View();
        }

        public ActionResult DoctorDashboard()
        {
            dataaccess_class data = new dataaccess_class();
            List<patientdata> pat = data.docdashboard();
            return View(pat);
        }

        public ActionResult ConfirmPatient(int logid)
        {
            dataaccess_class data = new dataaccess_class();
           
            data.confirmpatient(logid);

            return RedirectToAction("DoctorDashboard", "Doctor");
        }
        public ActionResult DoctorPrescription( )
        {
            return View();
        }


    }
}