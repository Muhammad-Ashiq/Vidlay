namespace Vidlay.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUser : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'33ed3dae-0492-4aac-84f9-5b84216ce085', N'admin@vidlay.com', 0, N'AFKZN3j9WDbiT8zIrZ1rQ98ymBMsy9WKFdQ1rI59XiB8P8OXPZR9NEWXbWP5ue6KcA==', N'13c25027-6625-444b-8b2e-06d39dc58d96', NULL, 0, 0, NULL, 1, 0, N'admin@vidlay.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'be5ea296-6ea5-4d3f-98a4-49280174bed0', N'guest@vidlay.com', 0, N'AIv3WTAywz+whVl91IQLqhdyrbbBmLv7n6CuB0FWJ5kq2hZJ63/8J6Z3bwGk4iV21Q==', N'd69e644d-c182-40ec-bddb-1c81b3b4b108', NULL, 0, 0, NULL, 1, 0, N'guest@vidlay.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'3199a39f-f69e-4fa5-8aa1-f552a9981cf6', N'Can Manage Movies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'33ed3dae-0492-4aac-84f9-5b84216ce085', N'3199a39f-f69e-4fa5-8aa1-f552a9981cf6')


");
        }
        
        public override void Down()
        {
        }
    }
}
