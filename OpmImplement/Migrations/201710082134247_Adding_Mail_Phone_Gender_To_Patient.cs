namespace OpmImplement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Adding_Mail_Phone_Gender_To_Patient : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patients", "Email", c => c.String());
            AddColumn("dbo.Patients", "PhoneNumber", c => c.String());
            AddColumn("dbo.Patients", "Gender", c => c.String(maxLength: 1));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Patients", "Gender");
            DropColumn("dbo.Patients", "PhoneNumber");
            DropColumn("dbo.Patients", "Email");
        }
    }
}
