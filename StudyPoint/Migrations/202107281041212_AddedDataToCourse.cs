namespace StudyPoint.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDataToCourse : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "Data", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Courses", "Data");
        }
    }
}
