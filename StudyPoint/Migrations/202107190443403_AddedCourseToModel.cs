namespace StudyPoint.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCourseToModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "Price", c => c.Int(nullable: false));
            AddColumn("dbo.Courses", "InstructorName", c => c.String());
            AddColumn("dbo.Courses", "Category", c => c.String());
            DropColumn("dbo.Courses", "MyProperty");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Courses", "MyProperty", c => c.Int(nullable: false));
            DropColumn("dbo.Courses", "Category");
            DropColumn("dbo.Courses", "InstructorName");
            DropColumn("dbo.Courses", "Price");
        }
    }
}
