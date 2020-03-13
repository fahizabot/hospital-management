﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer;
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
            
            dataaccess_class data = new dataaccess_class();
            List<doctordata> docs = data.doctorrequest();
            return View(docs);
        }
        public ActionResult confirmdoctor(int docid)
        {
            dataaccess_class data = new dataaccess_class();
            data.confirmdoctor(docid);

            return RedirectToAction("DoctorRequest", "Admin");
        }

        public ActionResult DoctorActionflow()
        {
            return View();
        }


    }
}