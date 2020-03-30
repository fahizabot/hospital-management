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
            if (ModelState.IsValid)
            {
                dataaccess_class dac = new dataaccess_class();
                dac.patientdetails(model.UserName, model.Mail, model.Age, model.MobileNumber, model.Address, model.PassWord);
            }
                return View();
            
        }

        public ActionResult PatientHomepage()
        {
            return View();
        }
        public ActionResult PatientDashboard()
        {
             dataaccess_class data = new dataaccess_class();
            int id = int.Parse(Session["loginid"].ToString());
            List<patientdata> apd = data.patdashboard(id);
            return View(apd);
            
        }
        public ActionResult PayDoctor(int appid)
        {
            dataaccess_class data = new dataaccess_class();
           
            data.paydoctor(appid);

            return RedirectToAction("PatientDashboard", "Patient");
           
        }
        public ActionResult Speciality()
        {
            
            return View();
        }
        public ActionResult HospitalDetails(int spid)
        {
            dataaccess_class dac = new dataaccess_class();
            List<hospitaldata> hosp = dac.chooshosp(spid);
            return View(hosp);
        }
        public ActionResult ChooseDoctor(int hpid)
        {
            dataaccess_class dac = new dataaccess_class();
            List<choosedocdata> doc = dac.choosedoc(hpid);
            return View(doc);
        } 

        public ActionResult Appointment(int docid)
        {
            if (ModelState.IsValid)
            {
                dataaccess_class dac = new dataaccess_class();
                Session["docid"] = docid;
            }
            return View();
        }
        [HttpPost]
        public ActionResult Appointment(appointment model)
        {
            dataaccess_class dac = new dataaccess_class();
            int userid = int.Parse(Session["userid"].ToString());
            int loginid = int.Parse(Session["loginid"].ToString());
            dac.addappointment(model.UserName,  model.Timings, model.Slot, model.Description, userid,loginid,int.Parse(Session["docid"].ToString()));
            return View();
        }

    }
}