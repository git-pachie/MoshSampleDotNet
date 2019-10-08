namespace SampleMosh.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixEmployee2 : DbMigration
    {
        public override void Up()
        {
            AddForeignKey("dbo.EmployeeFavoriteFoods", "EmployeeId", "dbo.Employees", "Id", cascadeDelete: true);
            CreateIndex("dbo.EmployeeFavoriteFoods", "EmployeeId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.EmployeeFavoriteFoods", new[] { "EmployeeId" });
            DropForeignKey("dbo.EmployeeFavoriteFoods", "EmployeeId", "dbo.Employees");
        }
    }
}
