namespace WebApplication7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SchoolModelModified : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Classes", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Classes", new[] { "DepartmentId" });
            DropColumn("dbo.Classes", "DepartmentId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Classes", "DepartmentId", c => c.Int());
            CreateIndex("dbo.Classes", "DepartmentId");
            AddForeignKey("dbo.Classes", "DepartmentId", "dbo.Departments", "Id");
        }
    }
}
