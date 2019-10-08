namespace SampleMosh.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFovoritteFood : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FovoriteFoods", "Employee_Id", "dbo.Employees");
            DropIndex("dbo.FovoriteFoods", new[] { "Employee_Id" });
            AddColumn("dbo.FovoriteFoods", "Employees_Id", c => c.Int());
            AddForeignKey("dbo.FovoriteFoods", "Employees_Id", "dbo.Employees", "Id");
            CreateIndex("dbo.FovoriteFoods", "Employees_Id");
            DropColumn("dbo.FovoriteFoods", "Employee_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FovoriteFoods", "Employee_Id", c => c.Int());
            DropIndex("dbo.FovoriteFoods", new[] { "Employees_Id" });
            DropForeignKey("dbo.FovoriteFoods", "Employees_Id", "dbo.Employees");
            DropColumn("dbo.FovoriteFoods", "Employees_Id");
            CreateIndex("dbo.FovoriteFoods", "Employee_Id");
            AddForeignKey("dbo.FovoriteFoods", "Employee_Id", "dbo.Employees", "Id");
        }
    }
}
