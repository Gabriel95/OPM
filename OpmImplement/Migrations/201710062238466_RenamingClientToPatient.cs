namespace OpmImplement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenamingClientToPatient : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Records", "Client_ClientId", "dbo.Clients");
            DropIndex("dbo.Records", new[] { "Client_ClientId" });
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        PatientId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        Age = c.Int(nullable: false),
                        Occupation = c.String(),
                    })
                .PrimaryKey(t => t.PatientId);
            
            AddColumn("dbo.Records", "Patient_PatientId", c => c.Int());
            CreateIndex("dbo.Records", "Patient_PatientId");
            AddForeignKey("dbo.Records", "Patient_PatientId", "dbo.Patients", "PatientId");
            DropColumn("dbo.Records", "Client_ClientId");
            DropTable("dbo.Clients");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        ClientId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        Age = c.Int(nullable: false),
                        Occupation = c.String(),
                    })
                .PrimaryKey(t => t.ClientId);
            
            AddColumn("dbo.Records", "Client_ClientId", c => c.Int());
            DropForeignKey("dbo.Records", "Patient_PatientId", "dbo.Patients");
            DropIndex("dbo.Records", new[] { "Patient_PatientId" });
            DropColumn("dbo.Records", "Patient_PatientId");
            DropTable("dbo.Patients");
            CreateIndex("dbo.Records", "Client_ClientId");
            AddForeignKey("dbo.Records", "Client_ClientId", "dbo.Clients", "ClientId");
        }
    }
}
