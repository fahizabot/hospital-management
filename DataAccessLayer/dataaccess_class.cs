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
            log.LoginId = data.LoginId;
            log.RoleId = data.RoleId;
            return log;
        }

        public void doctordetails(string UserName, string Mail,int age, string MobileNumber, string Address, int Experience, int Fees, string PassWord,int hosp,int spec)
        {
            database_class dac = new database_class();
            UserDetail us = new UserDetail();
            us.Age = age;
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
            Doctor doc = new Doctor();
            doc.Experience = Experience;
            doc.Fees = Fees;
            doc.HospitalId = hosp;
            doc.SpecialistId = spec;
            doc.LoginId = lg.LoginId;
            doc.status = "Requested";
            dac.Doctors.Add(doc);
            dac.SaveChanges();           
        }
        

        public void patientdetails(string UserName, string Mail,int Age, string MobileNumber, string Address, string PassWord)
        {
            database_class dac = new database_class();
            UserDetail us = new UserDetail();
            us.Age =Age;
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
        
        public void addappointment(  string UserName ,  int Timings ,string Slot, string Description,int userid,int loginid,int docid)
        {
            database_class dac = new database_class();
            Appointment app = new Appointment();
            app.Status = "requested";
            app.Timimgs = Timings;
            app.Slot = Slot;
            app.Pay="pay";
            app.Description = Description;
            //app.Prescription = "usedef";//not required
            app.LoginId = (from i in dac.Logins where i.UserId == userid select i.LoginId).FirstOrDefault();
            app.DoctorId = docid;
            dac.Appointments.Add(app);
            dac.SaveChanges();

            History history = new History();
            history.AppointmentId = app.AppointmentId;
            history.FromStatus = "none";
            history.ToStatus = "requested";
            history.LoginId = loginid;
            dac.Histories.Add(history);
            dac.SaveChanges();

        }
        public List<patientdata> patdashboard(int loginid)
        {
            database_class data =new database_class();
            var appoint= from i in data.Appointments where i.LoginId==loginid  select i;
           List<patientdata> apd = new List<patientdata>();
            foreach(var i in appoint)
                {
                patientdata app = new patientdata();
                app.AppointmentId=i.AppointmentId;
                app.Status=i.Status;
                app.Slot = i.Slot;
                app.Timings = i.Timimgs;
                app.Pay=i.Pay;
                app.Description=i.Description;
                app.Prescription=i.Prescription;
                apd.Add(app);
                }
            return apd;
        }
         public void paydoctor(int appid)
        {
            database_class database = new database_class();
            var app = (from i in database.Appointments where i.AppointmentId == appid select i).SingleOrDefault();
            app.Pay = "paid";
            database.SaveChanges();
        }


        public List<patientdata> docdashboard(int loginid)
        {
            database_class database = new database_class();
            int docid = (from i in database.Doctors where i.LoginId == loginid select i.DoctorId).FirstOrDefault();
            var appoint = from i in database.Appointments where i.DoctorId==docid select i;
            List<patientdata> pat = new List<patientdata>();
            foreach (var i in appoint)
            {
                patientdata patdata = new patientdata();
                patdata.AppointmentId = i.AppointmentId;
                patdata.Status = i.Status;
                patdata.Timings = i.Timimgs;
                patdata.Slot = i.Slot;
                patdata.Pay = i.Pay;
                patdata.Description = i.Description;
                pat.Add(patdata);
            }
            return pat;
        }
        public void confirmpatient(int appid,int loginid)
        {
            database_class database = new database_class();
            var pat = (from i in database.Appointments where i.AppointmentId == appid select i).FirstOrDefault();
            pat.Status = "confirmed";
            database.SaveChanges();

            History history = new History();
            history.AppointmentId = appid;
            history.FromStatus = "requested";
            history.ToStatus = "confirm";
            history.LoginId = loginid;
            database.Histories.Add(history);
            database.SaveChanges();
        }

        public void cancelpatient(int appid,int loginid)
        {
            database_class database = new database_class();
            var pat = (from i in database.Appointments where i.AppointmentId == appid select i).FirstOrDefault();
            pat.Status = "cancelled";
            database.SaveChanges();

            History history = new History();
            history.AppointmentId = appid;
            history.FromStatus = "requested";
            history.ToStatus = "cancelled";
            history.LoginId = loginid;
            database.Histories.Add(history);
            database.SaveChanges();
        }

        public List<hospitaldata> chooshosp(int spid)
        {
            database_class database = new database_class();
            var sps = (from i in database.Doctors where i.SpecialistId == spid select i.HospitalId).Distinct();
            List<hospitaldata> hosp = new List<hospitaldata>();
            foreach(var i in sps)
            {
                var hospital = from k in database.Hospitals where k.HospitalId==i select k;
                foreach (var j in hospital)
                {
                    hospitaldata hd = new hospitaldata();
                    hd.hospitalId = j.HospitalId;
                    hd.hospitalName = j.HospitalName;
                    hd.MobileNumber = j.MobileNumber;
                    hd.Address = j.Address;
                    hosp.Add(hd);
                }
            }
             return hosp;
        }
        public List<hospitaldata> hospitals()
        {
            database_class database = new database_class();
            var hospitals = from i in database.Hospitals select i;
            List<hospitaldata> hosp = new List<hospitaldata>();

            foreach (var j in hospitals)
            {
                hospitaldata hd = new hospitaldata();
                hd.hospitalId = j.HospitalId;
                hd.hospitalName = j.HospitalName;
                hd.MobileNumber = j.MobileNumber;
                hd.Address = j.Address;
                hosp.Add(hd);
            }
            return hosp;

        }
        public List<specialitydata>speciality()
        {
            database_class database = new database_class();
            var speciality = from i in database.Specialists select i;
            List<specialitydata> spec = new List<specialitydata>();
            foreach (var j in speciality)
            {
                specialitydata spd = new specialitydata();
                spd.SpecialistId = j.SpecialistId;
                spd.SpecialistName = j.SpecialistName;
                spec.Add(spd);
            }
            return spec;
        }

        public List<choosedocdata> choosedoc(int hospid)
        {
            database_class database = new database_class();
            var chdo = (from i in database.Doctors where i.HospitalId == hospid select i.LoginId).Distinct();
            List<choosedocdata> doc = new List<choosedocdata>();
            foreach (var i in chdo)
            {
                var doctor = from k in database.Logins.Include("User_Id") where k.LoginId == i select k;
                foreach (var j in doctor)
                {
                    choosedocdata cd = new choosedocdata();
                    cd.DoctorId = (from k in database.Doctors where k.LoginId==j.LoginId select k.DoctorId).FirstOrDefault();
                    cd.DoctorName = j.UserName;
                    cd.Address = j.User_Id.Address;
                    cd.MobileNumber = j.User_Id.MobileNumber;
                    doc.Add(cd);
                }
            }
            return doc;
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
        public List<patientdata>actionflow()
        {
           database_class database = new database_class();
            //int docid = (from i in database.Doctors where i.LoginId == loginid select i.DoctorId).FirstOrDefault();
            var appoint = from i in database.Appointments select i;
            List<patientdata> pat = new List<patientdata>();
            foreach (var i in appoint)
            {
                patientdata patdata = new patientdata();
                patdata.AppointmentId = i.AppointmentId;
                patdata.DoctorId=i.DoctorId;
                patdata.LoginId=i.LoginId;
                patdata.Status = i.Status;
                patdata.Prescription = i.Prescription;
                patdata.Timings = i.Timimgs;
                patdata.Slot = i.Slot;
                patdata.Pay = i.Pay;
                patdata.Description = i.Description;
                pat.Add(patdata);
            }
            return pat;
        }
       
        public void confirmdoctor(int docid)
        {
            database_class database = new database_class();
            var doc = (from i in database.Doctors where i.DoctorId == docid select i).SingleOrDefault();
            doc.status = "confirmed";
            database.SaveChanges();
        }
        public void addprescription(string prescription, int appointmentid)
        {
            database_class database = new database_class();
            var appointment = (from i in database.Appointments where i.AppointmentId == appointmentid select i).SingleOrDefault();
            int docid = appointment.DoctorId;
            appointment.Prescription = prescription;
            appointment.Status = "completed";
            database.SaveChanges();
            History history = new History();
            history.AppointmentId = appointmentid;
            history.FromStatus = "confirmed";
            history.ToStatus = "completed";
            history.LoginId = (from i in database.Doctors where i.DoctorId == docid select i.LoginId).FirstOrDefault();
            database.Histories.Add(history);
            database.SaveChanges();

        }
        public List<Historydata> appointhistory(int appointmentid)
        {
            database_class database = new database_class();
            var histories = from i in database.Histories where i.AppointmentId == appointmentid select i;
            List<Historydata> historydatas = new List<Historydata>();
            foreach(var i in histories)
            {
                Historydata h = new Historydata();
                h.AppointmentId = i.AppointmentId;
                h.FromStatus = i.FromStatus;
                h.LoginId = i.LoginId;
                h.RequestId = i.RequestId;
                h.ToStatus = i.ToStatus;
                historydatas.Add(h);
            }
            return historydatas;
        }

    }
    
    public class logindata
    {
        public int LoginId { get; set; }
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
    public class patientdata
    {
        public int LoginId { get; set; }
        public int DoctorId { get; set; }
        public string Status { get; set; }
        public int Timings { get; set; }
        public string Pay { get; set; }
        public string Description { get; set; }
        public string Slot { get; set; }
        public int AppointmentId { get; set; }
        public string Prescription { get; set; }

    }
    public class hospitaldata
    {
        public int hospitalId { get; set; }
        public string hospitalName{ get; set; }
        public string MobileNumber { get; set; }
        public string Address { get; set; }


    }
    public class choosedocdata
    { 
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public string MobileNumber { get; set; }
        public string Address { get; set; }
    }
    public class appointdata
    {
        public int docid { get; set; }
       
    }
    public class Historydata
    {
       
        public int RequestId { get; set; }
        public int LoginId { get; set; }
        public int AppointmentId { get; set; }
        public string FromStatus { get; set; }
        public string ToStatus { get; set; }
    }
    public class specialitydata
    { 
        public int SpecialistId { get; set; }
        public string SpecialistName { get; set; }
    }
}



 
