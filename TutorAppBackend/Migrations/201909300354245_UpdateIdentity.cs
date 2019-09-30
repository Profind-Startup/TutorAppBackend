namespace TutorAppBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateIdentity : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
        }
        
        public override void Down()
        {
            AddForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles", "Id", cascadeDelete: true);
        }
    }
}
