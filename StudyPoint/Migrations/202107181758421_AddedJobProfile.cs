namespace StudyPoint.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedJobProfile : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.JobProfiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Customers", "Email", c => c.String());
            AddColumn("dbo.Customers", "JobProfileId", c => c.Int(nullable: false));
            CreateIndex("dbo.Customers", "JobProfileId");
            AddForeignKey("dbo.Customers", "JobProfileId", "dbo.JobProfiles", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "JobProfileId", "dbo.JobProfiles");
            DropIndex("dbo.Customers", new[] { "JobProfileId" });
            DropColumn("dbo.Customers", "JobProfileId");
            DropColumn("dbo.Customers", "Email");
            DropTable("dbo.JobProfiles");
        }
    }
}
