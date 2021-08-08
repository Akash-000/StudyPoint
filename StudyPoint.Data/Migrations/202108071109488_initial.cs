namespace StudyPoint.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CourseDifficultyLevels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DifficultyLevel = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Price = c.Int(nullable: false),
                        InstructorName = c.String(),
                        Category = c.String(nullable: false),
                        CourseDifficultyLevelId = c.Int(nullable: false),
                        Data = c.Binary(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CourseDifficultyLevels", t => t.CourseDifficultyLevelId, cascadeDelete: true)
                .Index(t => t.CourseDifficultyLevelId);
            
            CreateTable(
                "dbo.DiscussionBoardModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DiscussionMessage = c.String(nullable: false, maxLength: 200),
                        CustomerUserName = c.String(),
                        Name = c.String(),
                        Occupation = c.String(),
                        MobileNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FeedbackMsgs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerUserName = c.String(),
                        Message = c.String(nullable: false, maxLength: 200),
                        Name = c.String(),
                        Occupation = c.String(),
                        MobileNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "CourseDifficultyLevelId", "dbo.CourseDifficultyLevels");
            DropIndex("dbo.Courses", new[] { "CourseDifficultyLevelId" });
            DropTable("dbo.FeedbackMsgs");
            DropTable("dbo.DiscussionBoardModels");
            DropTable("dbo.Courses");
            DropTable("dbo.CourseDifficultyLevels");
        }
    }
}
