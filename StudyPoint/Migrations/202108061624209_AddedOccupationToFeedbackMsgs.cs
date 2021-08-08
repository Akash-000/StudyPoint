namespace StudyPoint.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedOccupationToFeedbackMsgs : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FeedbackMsgs", "Occupation", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.FeedbackMsgs", "Occupation");
        }
    }
}
