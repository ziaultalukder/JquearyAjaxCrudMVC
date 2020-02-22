namespace WebApplication7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DepartmentAndClassModelModified : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Departments", "SchoolId", "dbo.Schools");
            DropForeignKey("dbo.Classes", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Departments", new[] { "SchoolId" });
            DropIndex("dbo.Classes", new[] { "DepartmentId" });
            CreateTable(
                "dbo.DepartmentViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AlterColumn("dbo.Classes", "DepartmentId", c => c.Int());
            CreateIndex("dbo.Classes", "DepartmentId");
            AddForeignKey("dbo.Classes", "DepartmentId", "dbo.Departments", "Id");
            DropColumn("dbo.Departments", "SchoolId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Departments", "SchoolId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Classes", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Classes", new[] { "DepartmentId" });
            AlterColumn("dbo.Classes", "DepartmentId", c => c.Int(nullable: false));
            DropTable("dbo.DepartmentViewModels");
            CreateIndex("dbo.Classes", "DepartmentId");
            CreateIndex("dbo.Departments", "SchoolId");
            AddForeignKey("dbo.Classes", "DepartmentId", "dbo.Departments", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Departments", "SchoolId", "dbo.Schools", "Id", cascadeDelete: true);
        }
    }
}
