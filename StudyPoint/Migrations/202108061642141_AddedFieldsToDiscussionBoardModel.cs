namespace StudyPoint.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFieldsToDiscussionBoardModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DiscussionBoardModels", "Name", c => c.String());
            AddColumn("dbo.DiscussionBoardModels", "Occupation", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DiscussionBoardModels", "Occupation");
            DropColumn("dbo.DiscussionBoardModels", "Name");
        }
    }
}
