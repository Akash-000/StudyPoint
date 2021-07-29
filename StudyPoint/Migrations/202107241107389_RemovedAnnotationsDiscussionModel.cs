namespace StudyPoint.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedAnnotationsDiscussionModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DiscussionBoardModels", "DiscussionMessage", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DiscussionBoardModels", "DiscussionMessage", c => c.String(nullable: false, maxLength: 200));
        }
    }
}
