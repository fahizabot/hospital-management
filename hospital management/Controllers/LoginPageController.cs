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
        public ActionResult SignIn(loginmodel model)
        {
            return View();

        }

        
       
        
    }
}