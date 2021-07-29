namespace StudyPoint.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetNameOfJobProfile : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE JobProfiles SET Name = 'Student' WHERE Id = 1");
            Sql("UPDATE JobProfiles SET Name = 'Free-Lancer' WHERE Id = 2");
            Sql("UPDATE JobProfiles SET Name = 'Developers' WHERE Id = 3");
        }
        
        public override void Down()
        {
        }
    }
}
