namespace StudyPoint.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FeedbackClassAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FeedbackMsgs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Message = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.FeedbackMsgs");
        }
    }
}
