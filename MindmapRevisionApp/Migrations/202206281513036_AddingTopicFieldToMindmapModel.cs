namespace MindmapRevisionApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingTopicFieldToMindmapModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Mindmaps", "Topic", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Mindmaps", "Topic");
        }
    }
}
