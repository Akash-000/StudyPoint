namespace StudyPoint.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDiscussionBoardModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DiscussionBoardModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DiscussionMessage = c.String(nullable: false, maxLength: 200),
                        CustomerUserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AlterColumn("dbo.FeedbackMsgs", "Message", c => c.String(nullable: false, maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.FeedbackMsgs", "Message", c => c.String());
            DropTable("dbo.DiscussionBoardModels");
        }
    }
}
