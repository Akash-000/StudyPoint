namespace StudyPoint.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedCustomerAndJobProfile : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "JobProfileId", "dbo.JobProfiles");
            DropIndex("dbo.Customers", new[] { "JobProfileId" });
            DropTable("dbo.Customers");
            DropTable("dbo.JobProfiles");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.JobProfiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Address = c.String(),
                        PhoneNumber = c.String(),
                        Email = c.String(),
                        JobProfileId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Customers", "JobProfileId");
            AddForeignKey("dbo.Customers", "JobProfileId", "dbo.JobProfiles", "Id", cascadeDelete: true);
        }
    }
}
