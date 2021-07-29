namespace StudyPoint.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAnnotationDiscussionModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DiscussionBoardModels", "DiscussionMessage", c => c.String(nullable: false, maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DiscussionBoardModels", "DiscussionMessage", c => c.String());
        }
    }
}
