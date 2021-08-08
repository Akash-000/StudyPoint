namespace StudyPoint.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                    INSERT INTO [dbo].[AspNetUsers] ([Id], [Address], [MobileNumber], [Occupation], [Name], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'0f371787-7ccc-4fee-9591-15316944cde0', N'Haryana', N'7982944708', N'Intern', N'Akash', N'akashchauhan@gmail.com', 0, N'ACFftiDF/GQPocsdOyWplu1c/p7IbdX+HOtqu0P8oUbFPGK6AFQm4GlKZT+6oKysbQ==', N'df15f4ac-d477-4be8-9609-fcae43e3b606', NULL, 0, 0, NULL, 1, 0, N'akashchauhan@gmail.com')
                    INSERT INTO [dbo].[AspNetUsers] ([Id], [Address], [MobileNumber], [Occupation], [Name], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'd028af84-96b4-47cf-a4c0-2b5491460c74', N'Bangalore', N'9999888877', N'Admin', N'Admin', N'admin@studypoint.com', 0, N'ADIgyyeU7k4+n0Z+GDhu3VTbNLZouX3vzvcG5s68OfH4bBfm9kWpImo9QRq7j0ynMQ==', N'91e5882b-c2f6-4118-88f6-aca2f9292c7d', NULL, 0, 0, NULL, 1, 0, N'admin@studypoint.com')

                    INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'3fe00cad-a3b9-412a-9232-f12f0026c96f', N'Admin')

                    INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'd028af84-96b4-47cf-a4c0-2b5491460c74', N'3fe00cad-a3b9-412a-9232-f12f0026c96f')

            ");
        }
        
        public override void Down()
        {
        }
    }
}
