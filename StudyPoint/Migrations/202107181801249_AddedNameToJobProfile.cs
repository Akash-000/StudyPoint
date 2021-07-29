namespace StudyPoint.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedNameToJobProfile : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JobProfiles", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.JobProfiles", "Name");
        }
    }
}
