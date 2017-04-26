namespace vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'21baf144-1791-4d16-97d6-f23084e8d4c1', N'aiwei@gmail.com', 0, N'AIXpGcVCp7yqDDRphPExnyJGdDA/88RfeuaYk8n6Jucw4V5xGsOV+yJ1QpFr8Iqhww==', N'c90a4723-135a-4406-888f-7ac665c91ee1', NULL, 0, 0, NULL, 1, 0, N'aiwei@gmail.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'6bc93609-93d0-4144-965c-d9ec9daa8d8d', N'admin@gmail.com', 0, N'AKkFTl98qaY7hkamimGGNrDDqaDACZg+ScKFDKYdPyfQZN0aIkpeyRdNqnIUVcwKsA==', N'61e44f91-42d3-46cd-9d11-e54794134d1b', NULL, 0, 0, NULL, 1, 0, N'admin1@gmail.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'652302af-adb8-49ad-91d5-b2a2ebe44598', N'CanManagerMovie')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'6bc93609-93d0-4144-965c-d9ec9daa8d8d', N'652302af-adb8-49ad-91d5-b2a2ebe44598')


");
        }
        
        public override void Down()
        {
        }
    }
}
