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
            if (ModelState.IsValid)
            {
                dataaccess_class dac = new dataaccess_class();
                List<hospitaldata> hosp = dac.hospitals();
                SelectListItem[] hosps = new SelectListItem[hosp.Count];
                int j = 0;
                foreach (var i in hosp)
                {
                    hosps[j] = new SelectListItem() { Text = i.hospitalName, Value = i.hospitalId.ToString() };
                    j++;
                }
                ViewBag.hospitals = hosps;

                List<specialitydata> specialists = dac.speciality();
                SelectListItem[] spec = new SelectListItem[specialists.Count];
                int k = 0;
                foreach (var i in specialists)
                {
                    spec[k] = new SelectListItem() { Text = i.SpecialistName, Value = i.SpecialistId.ToString() };
                    k++;
                }
                ViewBag.specialists = spec;
            }
            return View();
        }
        [HttpPost]
        public ActionResult NewDoctor(newdoctor model)
        {
            dataaccess_class dac = new dataaccess_class();
           
            dac.doctordetails(model.UserName,model.Mail,model.Age,model.MobileNumber,model.Address,model.Experience,model.Fees,model.PassWord,model.HospitalName,model.SpecialistName);
            return RedirectToAction("SignIn", "LoginPage");
            
        }

        public ActionResult DoctorDashboard()
        {
            dataaccess_class data = new dataaccess_class();
            int id = int.Parse(Session["loginid"].ToString());
            List<patientdata> pat = data.docdashboard(id);
            return View(pat);
        }

        public ActionResult ConfirmPatient(int appid)
        {
            dataaccess_class data = new dataaccess_class();
           int loginid= int.Parse(Session["loginid"].ToString()); 
            data.confirmpatient(appid,loginid);

            return RedirectToAction("DoctorDashboard", "Doctor");
        }
        public ActionResult CancelPatient(int appid)
        {
            dataaccess_class data = new dataaccess_class();
            int loginid = int.Parse(Session["loginid"].ToString());
            data.cancelpatient(appid,loginid); 

            return RedirectToAction("DoctorDashboard", "Doctor");
        }
        public ActionResult DoctorPrescription(int appid )
        {
           Session["appid"] = appid;
            return View();
        }
        [HttpPost]
        public ActionResult DoctorPrescription(string prescription)
        {
            if (ModelState.IsValid)
            {
                dataaccess_class data = new dataaccess_class();
                int appid = int.Parse(Session["appid"].ToString());
                data.addprescription(prescription, appid);
            }
            return View();
        }


    }
}