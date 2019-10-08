namespace SampleMosh.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixEmployee : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EmployeeFavoriteFoods", "Employees_Id", "dbo.Employees");
            DropForeignKey("dbo.EmployeeFavoriteFoods", "CodeFovoriteFood_id", "dbo.CodeFavoriteFoods");
            DropIndex("dbo.EmployeeFavoriteFoods", new[] { "Employees_Id" });
            DropIndex("dbo.EmployeeFavoriteFoods", new[] { "CodeFovoriteFood_id" });
            AddColumn("dbo.EmployeeFavoriteFoods", "EmployeeId", c => c.Int(nullable: false));
            AddColumn("dbo.EmployeeFavoriteFoods", "CodeFavoriteId", c => c.Int(nullable: false));
            DropColumn("dbo.EmployeeFavoriteFoods", "Employees_Id");
            DropColumn("dbo.EmployeeFavoriteFoods", "CodeFovoriteFood_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EmployeeFavoriteFoods", "CodeFovoriteFood_id", c => c.Int());
            AddColumn("dbo.EmployeeFavoriteFoods", "Employees_Id", c => c.Int());
            DropColumn("dbo.EmployeeFavoriteFoods", "CodeFavoriteId");
            DropColumn("dbo.EmployeeFavoriteFoods", "EmployeeId");
            CreateIndex("dbo.EmployeeFavoriteFoods", "CodeFovoriteFood_id");
            CreateIndex("dbo.EmployeeFavoriteFoods", "Employees_Id");
            AddForeignKey("dbo.EmployeeFavoriteFoods", "CodeFovoriteFood_id", "dbo.CodeFavoriteFoods", "id");
            AddForeignKey("dbo.EmployeeFavoriteFoods", "Employees_Id", "dbo.Employees", "Id");
        }
    }
}
