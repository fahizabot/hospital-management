namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        AppointmentId = c.Int(nullable: false, identity: true),
                        LoginId = c.Int(nullable: false),
                        DoctorId = c.Int(nullable: false),
                        Status = c.String(nullable: false),
                        Timimgs = c.Int(nullable: false),
                        Pay = c.String(nullable: false),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.AppointmentId)
                .ForeignKey("dbo.Doctors", t => t.DoctorId, cascadeDelete: true)
                .ForeignKey("dbo.Logins", t => t.LoginId, cascadeDelete: false)
                .Index(t => t.LoginId)
                .Index(t => t.DoctorId);
            
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        DoctorId = c.Int(nullable: false, identity: true),
                        HospitalId = c.Int(nullable: false),
                        LoginId = c.Int(nullable: false),
                        Fees = c.Int(nullable: false),
                        Experience = c.Int(nullable: false),
                        SpecialistId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DoctorId)
                .ForeignKey("dbo.Hospitals", t => t.HospitalId, cascadeDelete: true)
                .ForeignKey("dbo.Logins", t => t.LoginId, cascadeDelete: false)
                .ForeignKey("dbo.Specialists", t => t.SpecialistId, cascadeDelete: false)
                .Index(t => t.HospitalId)
                .Index(t => t.LoginId)
                .Index(t => t.SpecialistId);
            
            CreateTable(
                "dbo.Hospitals",
                c => new
                    {
                        HospitalId = c.Int(nullable: false, identity: true),
                        HospitalName = c.String(nullable: false),
                        DoctorLimit = c.Int(nullable: false),
                        MobileNumber = c.Int(nullable: false),
                        Address = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.HospitalId);
            
            CreateTable(
                "dbo.Logins",
                c => new
                    {
                        LoginId = c.Int(nullable: false, identity: true),
                        RoleId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        UserName = c.String(nullable: false),
                        PassWord = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.LoginId)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.UserDetails", t => t.UserId, cascadeDelete: false)
                .Index(t => t.RoleId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                    })
                .PrimaryKey(t => t.RoleId);
            
            CreateTable(
                "dbo.UserDetails",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Age = c.Int(nullable: false),
                        MobileNumber = c.Int(nullable: false),
                        Mail = c.String(nullable: false),
                        Address = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Specialists",
                c => new
                    {
                        SpecialistId = c.Int(nullable: false, identity: true),
                        SpecialistName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.SpecialistId);
            
            CreateTable(
                "dbo.Histories",
                c => new
                    {
                        RequestId = c.Int(nullable: false, identity: true),
                        LoginId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                        FromStatus = c.String(nullable: false),
                        ToStatus = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.RequestId)
                .ForeignKey("dbo.Logins", t => t.LoginId, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: false)
                .Index(t => t.LoginId)
                .Index(t => t.RoleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Histories", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Histories", "LoginId", "dbo.Logins");
            DropForeignKey("dbo.Appointments", "LoginId", "dbo.Logins");
            DropForeignKey("dbo.Appointments", "DoctorId", "dbo.Doctors");
            DropForeignKey("dbo.Doctors", "SpecialistId", "dbo.Specialists");
            DropForeignKey("dbo.Doctors", "LoginId", "dbo.Logins");
            DropForeignKey("dbo.Logins", "UserId", "dbo.UserDetails");
            DropForeignKey("dbo.Logins", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Doctors", "HospitalId", "dbo.Hospitals");
            DropIndex("dbo.Histories", new[] { "RoleId" });
            DropIndex("dbo.Histories", new[] { "LoginId" });
            DropIndex("dbo.Logins", new[] { "UserId" });
            DropIndex("dbo.Logins", new[] { "RoleId" });
            DropIndex("dbo.Doctors", new[] { "SpecialistId" });
            DropIndex("dbo.Doctors", new[] { "LoginId" });
            DropIndex("dbo.Doctors", new[] { "HospitalId" });
            DropIndex("dbo.Appointments", new[] { "DoctorId" });
            DropIndex("dbo.Appointments", new[] { "LoginId" });
            DropTable("dbo.Histories");
            DropTable("dbo.Specialists");
            DropTable("dbo.UserDetails");
            DropTable("dbo.Roles");
            DropTable("dbo.Logins");
            DropTable("dbo.Hospitals");
            DropTable("dbo.Doctors");
            DropTable("dbo.Appointments");
        }
    }
}
