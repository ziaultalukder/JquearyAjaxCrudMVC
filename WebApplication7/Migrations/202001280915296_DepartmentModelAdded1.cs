namespace WebApplication7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DepartmentModelAdded1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Departments", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.Departments", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Departments", "SchoolId", c => c.Int(nullable: false));
            CreateIndex("dbo.Departments", "SchoolId");
            AddForeignKey("dbo.Departments", "SchoolId", "dbo.Schools", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Departments", "SchoolId", "dbo.Schools");
            DropIndex("dbo.Departments", new[] { "SchoolId" });
            DropColumn("dbo.Departments", "SchoolId");
            DropColumn("dbo.Departments", "IsDeleted");
            DropColumn("dbo.Departments", "IsActive");
        }
    }
}
