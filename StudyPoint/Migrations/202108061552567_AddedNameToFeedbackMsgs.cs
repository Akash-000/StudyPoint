namespace StudyPoint.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedNameToFeedbackMsgs : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FeedbackMsgs", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.FeedbackMsgs", "Name");
        }
    }
}
