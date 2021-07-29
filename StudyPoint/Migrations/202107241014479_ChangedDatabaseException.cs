namespace StudyPoint.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedDatabaseException : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FeedbackMsgs", "CustomerUserName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.FeedbackMsgs", "CustomerUserName");
        }
    }
}
