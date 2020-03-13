namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class statusupdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Doctors", "status", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Doctors", "status");
        }
    }
}
