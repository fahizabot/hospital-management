namespace DataAccessLayer
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class database_class : DbContext
    {
        // Your context has been configured to use a 'database_class' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'DataAccessLayer.database_class' database on your LocalDb instance. 
        // 

        // If you wish to target a different database and/or database provider, modify the 'database_class' 
        // connection string in the application configuration file.
        public database_class()
            : base("database_class")
        {
            Database.SetInitializer < database_class >( new DropCreateDatabaseIfModelChanges<database_class>());
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Login> Logins { get; set; }
        public virtual DbSet<UserDetail> UserDetails { get; set; }
        public virtual DbSet<Hospital> Hospitals { get; set; }
        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<Specialist> Specialists { get; set; }
        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<History> Histories { get; set; }
    }

  
   

public class Role
{
    [Required]
    [Key]
    public int RoleId { get; set; }
    [Required]
    public string RoleName { get; set; }

}
public class Login
{
    [Required]
    [Key]
    public int LoginId { get; set; }
    [ForeignKey("Role_Id")]
    [Required]
    public int RoleId { get; set; }
    public Role Role_Id { get; set; }
    [ForeignKey("User_Id")]
    [Required]
    public int UserId { get; set; }
    public UserDetail User_Id { get; set; }
    [Required]
    public string UserName { get; set; }
    [Required]
    public string PassWord { get; set; }
}
public class UserDetail
{
    [Key]
    [Required]
    public int UserId { get; set; }
    [Required]
    public int Age { get; set; }
    [Required]
    public string MobileNumber { get; set; }
    [Required]
    public string Mail { get; set; }
    [Required]
   
   public string Address { get; set; }
}
public class Hospital
{
    [Key]
    [Required]
    public int HospitalId { get; set; }
    [Required]
    public string HospitalName { get; set; }
    [Required]
    public int DoctorLimit { get; set; }
    [Required]
    public string MobileNumber { get; set; }
    [Required]
    public string Address { get; set; }

}
public class Doctor
{
    [Key]
    [Required]
    public int DoctorId { get; set; }
    [ForeignKey("Hospital_Id")]
    [Required]
    public int HospitalId { get; set; }
    public Hospital Hospital_Id { get; set; }
    [ForeignKey("Login_Id")]
    [Required]
    public int LoginId { get; set; }
    public Login Login_Id { get; set; }
    [Required]
    public int Fees { get; set; }
    [Required]
    public int Experience { get; set; }
    [ForeignKey("Specialist_Id")]
    [Required]
    public int SpecialistId { get; set; }
    public Specialist Specialist_Id { get; set; }
        public string status { get; set; }
}
public class Specialist
{
    [Key]
    [Required]
    public int SpecialistId { get; set; }
    [Required]
     
        public string SpecialistName { get; set; }
}
public class Appointment
{
    [Key]
    [Required]
    public int AppointmentId { get; set; }
    [ForeignKey("Login_Id")]
    [Required]
    public int LoginId { get; set; }
    public Login Login_Id { get; set; }
    [ForeignKey("Doctor_Id")]
    [Required]
    public int DoctorId { get; set; }
    public Doctor Doctor_Id { get; set; }
    [Required]
    public string Status { get; set; }
    [Required]
    public int Timimgs { get; set; }
    [Required]
    public string Slot { get; set; }
    [Required]
    public string Pay { get; set; }
    [Required]
    public string Description { get; set; }
   public string Prescription { get; set; }
    }
public class History
{
    [Key]
    [Required]
    public int RequestId { get; set; }
   
        [ForeignKey("Login_Id")]
    [Required]
    public int LoginId { get; set; }
    public Login Login_Id { get; set; }
    
       [ForeignKey("appointment_id")]
    [Required]
    public int AppointmentId { get; set; }
  public Appointment appointment_id { get; set; }
   
        [Required]
    public string FromStatus { get; set; }
    
        [Required]
    public string ToStatus { get; set; }
}
         
}

