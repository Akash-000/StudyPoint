namespace StudyPoint.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCourseDifficultyLevel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CourseDifficultyLevels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Courses", "CourseDifficultyLevelId", c => c.Int(nullable: false));
            CreateIndex("dbo.Courses", "CourseDifficultyLevelId");
            AddForeignKey("dbo.Courses", "CourseDifficultyLevelId", "dbo.CourseDifficultyLevels", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "CourseDifficultyLevelId", "dbo.CourseDifficultyLevels");
            DropIndex("dbo.Courses", new[] { "CourseDifficultyLevelId" });
            DropColumn("dbo.Courses", "CourseDifficultyLevelId");
            DropTable("dbo.CourseDifficultyLevels");
        }
    }
}
