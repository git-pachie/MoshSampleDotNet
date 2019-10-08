namespace SampleMosh.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixEmployeeFavoriteFood : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EmployeeFovoriteFoods", "Employees_Id", "dbo.Employees");
            DropForeignKey("dbo.EmployeeFovoriteFoods", "CodeFovoriteFood_id", "dbo.CodeFavoriteFoods");
            DropIndex("dbo.EmployeeFovoriteFoods", new[] { "Employees_Id" });
            DropIndex("dbo.EmployeeFovoriteFoods", new[] { "CodeFovoriteFood_id" });
            CreateTable(
                "dbo.EmployeeFavoriteFoods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Employees_Id = c.Int(),
                        CodeFovoriteFood_id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.Employees_Id)
                .ForeignKey("dbo.CodeFavoriteFoods", t => t.CodeFovoriteFood_id)
                .Index(t => t.Employees_Id)
                .Index(t => t.CodeFovoriteFood_id);
            
            DropTable("dbo.EmployeeFovoriteFoods");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.EmployeeFovoriteFoods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Employees_Id = c.Int(),
                        CodeFovoriteFood_id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropIndex("dbo.EmployeeFavoriteFoods", new[] { "CodeFovoriteFood_id" });
            DropIndex("dbo.EmployeeFavoriteFoods", new[] { "Employees_Id" });
            DropForeignKey("dbo.EmployeeFavoriteFoods", "CodeFovoriteFood_id", "dbo.CodeFavoriteFoods");
            DropForeignKey("dbo.EmployeeFavoriteFoods", "Employees_Id", "dbo.Employees");
            DropTable("dbo.EmployeeFavoriteFoods");
            CreateIndex("dbo.EmployeeFovoriteFoods", "CodeFovoriteFood_id");
            CreateIndex("dbo.EmployeeFovoriteFoods", "Employees_Id");
            AddForeignKey("dbo.EmployeeFovoriteFoods", "CodeFovoriteFood_id", "dbo.CodeFavoriteFoods", "id");
            AddForeignKey("dbo.EmployeeFovoriteFoods", "Employees_Id", "dbo.Employees", "Id");
        }
    }
}
