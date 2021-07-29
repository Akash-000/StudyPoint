namespace StudyPoint.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedNameToCourse : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CourseDifficultyLevels", "DifficultyLevel", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CourseDifficultyLevels", "DifficultyLevel");
        }
    }
}
