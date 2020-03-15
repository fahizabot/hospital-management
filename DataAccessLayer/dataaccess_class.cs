using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class dataaccess_class
    {
        public logindata logindetails(string username, string password)
        {
            database_class dac = new database_class();
            var data = (from i in dac.Logins where i.UserName == username && i.PassWord == password select i).FirstOrDefault();
            logindata log = new logindata();
            log.UserId = data.UserId;
            log.RoleId = data.RoleId;
            return log;
        }

        public void doctordetails(string UserName, string Mail, string MobileNumber, string Address, string HospitalName, string SpecialistName, int Experience, int Fees, string PassWord)
        {
            database_class dac = new database_class();
            UserDetail us = new UserDetail();
            us.Age = 40;
            us.MobileNumber = MobileNumber;
            us.Mail = Mail;
            us.Address = Address;
            dac.UserDetails.Add(us);
            Login lg = new Login();
            lg.UserId = us.UserId;
            lg.RoleId = 2;
            lg.UserName = UserName;
            lg.PassWord = PassWord;
            dac.Logins.Add(lg);
            dac.SaveChanges();

            //   Hospital hop = new Hospital();
        }

        public void patientdetails(string UserName, string Mail, string MobileNumber, string Address, string PassWord)
        {
            database_class dac = new database_class();
            UserDetail us = new UserDetail();
            us.Age = 30;
            us.MobileNumber = MobileNumber;
            us.Mail = Mail;
            us.Address = Address;
            dac.UserDetails.Add(us);
            Login lg = new Login();
            lg.UserId = us.UserId;
            lg.RoleId = 3;
            lg.UserName = UserName;
            lg.PassWord = PassWord;
            dac.Logins.Add(lg);
            dac.SaveChanges();

        }
    }

        public List<doctordata> doctorrequest()
        {
            database_class database = new database_class();
            var doctors = from i in database.Doctors where i.status == "requested" select i;
            List<doctordata> docs = new List<doctordata>();
            foreach(var i in doctors)
            {
                doctordata doc = new doctordata();
                doc.DoctorId = i.DoctorId;
                doc.Experience = i.Experience;
                doc.Fees = i.Fees;
                doc.HospitalId = i.HospitalId;
                doc.LoginId = i.LoginId;
                doc.SpecialistId = i.SpecialistId;
                doc.status = i.status;
                docs.Add(doc);
            }
            return docs;
        }
        public void confirmdoctor(int docid)
        {
            database_class database = new database_class();
            var doc = (from i in database.Doctors where i.DoctorId == docid select i).SingleOrDefault();
            doc.status = "confirmed";
            database.SaveChanges();
        }
    }
    
    public class logindata
    {
        public int RoleId { get; set; }         
        public int UserId { get; set; }      
       
    }
    public class doctordata
    {
        public int DoctorId { get; set; }
      
        public int HospitalId { get; set; }
       
        public int LoginId { get; set; }
       
        public int Fees { get; set; }
     
        public int Experience { get; set; }
   
        public int SpecialistId { get; set; }
      
        public string status { get; set; }
    }

 
}
