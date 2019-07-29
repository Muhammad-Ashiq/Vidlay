namespace Vidlay.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedUserRole : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'3199a39f-f69e-4fa5-8aa1-f552a9981cf6', N'CanManageMovies')
");
        }
        
        public override void Down()
        {
        }
    }
}
