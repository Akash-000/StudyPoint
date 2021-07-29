namespace StudyPoint.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateNameInCourse : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE CourseDifficultyLevels SET DifficultyLevel = 'Beginners' WHERE Id = 1");
            Sql("UPDATE CourseDifficultyLevels SET DifficultyLevel = 'Intermediate' WHERE Id = 2");
            Sql("UPDATE CourseDifficultyLevels SET DifficultyLevel = 'Hard' WHERE Id = 3");
            Sql("UPDATE CourseDifficultyLevels SET DifficultyLevel = 'Experts' WHERE Id = 4");
        }
        
        public override void Down()
        {
        }
    }
}
