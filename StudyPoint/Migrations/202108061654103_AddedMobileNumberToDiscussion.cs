namespace StudyPoint.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedMobileNumberToDiscussion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DiscussionBoardModels", "MobileNumber", c => c.String());
            AddColumn("dbo.FeedbackMsgs", "MobileNumber", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.FeedbackMsgs", "MobileNumber");
            DropColumn("dbo.DiscussionBoardModels", "MobileNumber");
        }
    }
}
