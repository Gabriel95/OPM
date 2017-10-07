namespace OpmImplement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingUserandRoles : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Role_RoleId = c.Int(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Roles", t => t.Role_RoleId)
                .Index(t => t.Role_RoleId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.RoleId);
            
            AddColumn("dbo.Records", "CreatedBy_UserId", c => c.Int());
            CreateIndex("dbo.Records", "CreatedBy_UserId");
            AddForeignKey("dbo.Records", "CreatedBy_UserId", "dbo.Users", "UserId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Records", "CreatedBy_UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "Role_RoleId", "dbo.Roles");
            DropIndex("dbo.Users", new[] { "Role_RoleId" });
            DropIndex("dbo.Records", new[] { "CreatedBy_UserId" });
            DropColumn("dbo.Records", "CreatedBy_UserId");
            DropTable("dbo.Roles");
            DropTable("dbo.Users");
        }
    }
}
