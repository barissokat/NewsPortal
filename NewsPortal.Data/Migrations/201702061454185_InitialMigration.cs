namespace NewsPortal.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        LastName = c.String(),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false, maxLength: 8),
                        RegistrationDate = c.DateTime(nullable: false),
                        Active = c.Boolean(nullable: false),
                        Role_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Role", t => t.Role_ID)
                .Index(t => t.Role_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.User", "Role_ID", "dbo.Role");
            DropIndex("dbo.User", new[] { "Role_ID" });
            DropTable("dbo.User");
            DropTable("dbo.Role");
        }
    }
}
