namespace SampleMosh.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Employee : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employees", "Department_Id", "dbo.Departments");
            DropIndex("dbo.Employees", new[] { "Department_Id" });
            RenameColumn(table: "dbo.Employees", name: "Department_Id", newName: "DepartmentId");
            AddForeignKey("dbo.Employees", "DepartmentId", "dbo.Departments", "Id", cascadeDelete: true);
            CreateIndex("dbo.Employees", "DepartmentId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Employees", new[] { "DepartmentId" });
            DropForeignKey("dbo.Employees", "DepartmentId", "dbo.Departments");
            RenameColumn(table: "dbo.Employees", name: "DepartmentId", newName: "Department_Id");
            CreateIndex("dbo.Employees", "Department_Id");
            AddForeignKey("dbo.Employees", "Department_Id", "dbo.Departments", "Id");
        }
    }
}
