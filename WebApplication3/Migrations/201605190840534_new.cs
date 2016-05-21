namespace WebApplication3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _new : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Post",
                c => new
                    {
                        PostID = c.String(nullable: false, maxLength: 128),
                        DataPost = c.String(),
                        Title = c.String(),
                        content = c.String(),
                    })
                .PrimaryKey(t => t.PostID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Post");
        }
    }
}
