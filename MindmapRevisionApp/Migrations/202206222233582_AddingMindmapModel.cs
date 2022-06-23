namespace MindmapRevisionApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingMindmapModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Mindmaps",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Content = c.String(nullable: false),
                        RevisionsCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Mindmaps");
        }
    }
}
