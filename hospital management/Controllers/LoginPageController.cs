using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer;
using DataAccessLayer.model;
namespace hospital_management.Controllers

{
    public class LoginPageController : Controller
    {
        // GET: LoginPage
        public ActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignIn( loginmodel model)
        {
            if (ModelState.IsValid)
            {
                dataaccess_class dac = new dataaccess_class();
                logindata log = dac.logindetails(model.UserName, model.PassWord);
                Session["roleid"] = log.RoleId;
                Session["userid"] = log.UserId;
                if (log.RoleId == 1)
                {
                    return RedirectToAction("Admin_Dashboard", "Admin");
                }
                else if (log.RoleId == 2)
                {
                    return RedirectToAction("DoctorDashboard", "Doctor");
                }
                else if (log.RoleId == 3)
                {
                    return RedirectToAction("PatientHomepage", "Patient");
                }

            }
            return View();
        }

        
       
        
    }
}