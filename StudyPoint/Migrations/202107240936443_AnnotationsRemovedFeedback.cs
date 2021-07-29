namespace StudyPoint.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AnnotationsRemovedFeedback : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.FeedbackMsgs", "Message", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.FeedbackMsgs", "Message", c => c.String(nullable: false, maxLength: 200));
        }
    }
}
