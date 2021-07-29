namespace StudyPoint.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFeedbackModelAnnotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.FeedbackMsgs", "Message", c => c.String(nullable: false, maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.FeedbackMsgs", "Message", c => c.String());
        }
    }
}
