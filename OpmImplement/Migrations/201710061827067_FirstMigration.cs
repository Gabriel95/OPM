namespace OpmImplement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
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
            
            CreateTable(
                "dbo.Records",
                c => new
                    {
                        RecordId = c.Int(nullable: false, identity: true),
                        Observations = c.String(),
                        PreviousRx = c.String(),
                        DIP = c.Double(nullable: false),
                        LenseType = c.String(),
                        BifocalHeight = c.Double(nullable: false),
                        Client_ClientId = c.Int(),
                        LeftEye_RefractionId = c.Int(),
                        RightEye_RefractionId = c.Int(),
                    })
                .PrimaryKey(t => t.RecordId)
                .ForeignKey("dbo.Clients", t => t.Client_ClientId)
                .ForeignKey("dbo.Refractions", t => t.LeftEye_RefractionId)
                .ForeignKey("dbo.Refractions", t => t.RightEye_RefractionId)
                .Index(t => t.Client_ClientId)
                .Index(t => t.LeftEye_RefractionId)
                .Index(t => t.RightEye_RefractionId);
            
            CreateTable(
                "dbo.Refractions",
                c => new
                    {
                        RefractionId = c.Int(nullable: false, identity: true),
                        Spherical = c.Double(nullable: false),
                        Cilinder = c.Double(nullable: false),
                        Edge = c.Double(nullable: false),
                        Additional = c.Double(nullable: false),
                        FarVisualAcuity = c.String(),
                        CloseVisualAcuity = c.String(),
                    })
                .PrimaryKey(t => t.RefractionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Records", "RightEye_RefractionId", "dbo.Refractions");
            DropForeignKey("dbo.Records", "LeftEye_RefractionId", "dbo.Refractions");
            DropForeignKey("dbo.Records", "Client_ClientId", "dbo.Clients");
            DropIndex("dbo.Records", new[] { "RightEye_RefractionId" });
            DropIndex("dbo.Records", new[] { "LeftEye_RefractionId" });
            DropIndex("dbo.Records", new[] { "Client_ClientId" });
            DropTable("dbo.Refractions");
            DropTable("dbo.Records");
            DropTable("dbo.Clients");
        }
    }
}
