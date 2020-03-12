using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace hospital_management.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Admin_Dashboard()
        {
            return View();
        }

        public ActionResult DoctorRequest()
        {
            return View();
        }

        public ActionResult DoctorActionflow()
        {
            return View();
        }


    }
}