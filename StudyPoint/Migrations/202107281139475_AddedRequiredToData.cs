namespace StudyPoint.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRequiredToData : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Courses", "Data", c => c.Binary(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Courses", "Data", c => c.Binary());
        }
    }
}
