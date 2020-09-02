namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'051be28f-5525-41c3-8ca8-763b7ebb5ab5', N'guest@vidly.com', 0, N'AFRvtW0eZW3y3lv5rZtv/4jHfMV3YpKn8WD6WbZWse5Gd4FImkJfx+yzYcMBsH5ykw==', N'02dd097f-8db3-48f9-ae11-2a70b128b6c8', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'd57a3212-ed49-4f03-87bf-200e9933a34d', N'admin@vidly.com', 0, N'AM+4IOg2GKnqTrp1fpHgEOtGa++EPXGFjbC9Dt5WJ++VHuwBSX26HRoQD52dUNw/9A==', N'7539aca6-8485-434d-b78c-a6a5e1162dd7', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'fa9ade9d-52a7-430a-a6ef-09e5c8a68738', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'd57a3212-ed49-4f03-87bf-200e9933a34d', N'fa9ade9d-52a7-430a-a6ef-09e5c8a68738')

");
        }

        public override void Down()
        {
        }
    }
}
