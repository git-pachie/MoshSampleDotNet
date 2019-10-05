namespace SampleMosh.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateEmployees2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "Department_Id", c => c.Int());
            AddForeignKey("dbo.Employees", "Department_Id", "dbo.Departments", "Id");
            CreateIndex("dbo.Employees", "Department_Id");
            DropColumn("dbo.Employees", "DepartmentId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "DepartmentId", c => c.Int(nullable: false));
            DropIndex("dbo.Employees", new[] { "Department_Id" });
            DropForeignKey("dbo.Employees", "Department_Id", "dbo.Departments");
            DropColumn("dbo.Employees", "Department_Id");
        }
    }
}
