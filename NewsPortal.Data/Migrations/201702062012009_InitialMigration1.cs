namespace NewsPortal.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Image",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Images = c.String(),
                        News_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.News", t => t.News_ID)
                .Index(t => t.News_ID);
            
            CreateTable(
                "dbo.News",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 255),
                        Summary = c.String(),
                        Content = c.String(),
                        ReadCount = c.Int(nullable: false),
                        Active = c.Boolean(nullable: false),
                        UploadDate = c.DateTime(nullable: false),
                        User_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.User", t => t.User_ID)
                .Index(t => t.User_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.News", "User_ID", "dbo.User");
            DropForeignKey("dbo.Image", "News_ID", "dbo.News");
            DropIndex("dbo.News", new[] { "User_ID" });
            DropIndex("dbo.Image", new[] { "News_ID" });
            DropTable("dbo.News");
            DropTable("dbo.Image");
        }
    }
}
