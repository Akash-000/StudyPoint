namespace StudyPoint.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'7543fb2f-38df-47e5-b693-04f0bfcf0318', N'akash@gmail.com', 0, N'AJm6eKN7ZqR1N698w2YNvJEMEc+F9GnT9JDgZqkVIu0j+pzsWtVqlDZdMnOuzUjwjg==', N'a6f7b173-1ad0-40d5-9457-756b5680019f', NULL, 0, 0, NULL, 1, 0, N'akash@gmail.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'd6d1fec0-8de4-464b-a179-cb29a0942f39', N'admin@studypoint.com', 0, N'AP5d0mv7TYX26zsWxuQBRvVO3qLnIRbpLpPEpCErwpum3EjVW0h4UY2Mq7MkW13HpA==', N'6d04528e-68a0-4b7c-8052-93155b521d10', NULL, 0, 0, NULL, 1, 0, N'admin@studypoint.com')

                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'938666ed-b0f3-4ea3-b5a8-449c3c9e2adc', N'CanManageCourseAndCustomer')

                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'd6d1fec0-8de4-464b-a179-cb29a0942f39', N'938666ed-b0f3-4ea3-b5a8-449c3c9e2adc')

");
        }
        
        public override void Down()
        {
        }
    }
}
