using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace hospital_management.Controllers
{
    public class DoctorController : Controller
    {
        // GET: Doctor
        public ActionResult NewDoctor()
        {
            return View();
        }

        public ActionResult DoctorDashboard()
        {
            return View();
        }
        public ActionResult DoctorPrescription()
        {
            return View();
        }


    }
}