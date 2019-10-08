namespace SampleMosh.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFovoriteFoodCodes : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FovoriteFoods", "Employees_Id", "dbo.Employees");
            DropIndex("dbo.FovoriteFoods", new[] { "Employees_Id" });
            CreateTable(
                "dbo.EmployeeFovoriteFoods",
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
            
            CreateTable(
                "dbo.CodeFavoriteFoods",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        FoodName = c.String(),
                        SortOption = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            DropTable("dbo.FovoriteFoods");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.FovoriteFoods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Employees_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropIndex("dbo.EmployeeFovoriteFoods", new[] { "CodeFovoriteFood_id" });
            DropIndex("dbo.EmployeeFovoriteFoods", new[] { "Employees_Id" });
            DropForeignKey("dbo.EmployeeFovoriteFoods", "CodeFovoriteFood_id", "dbo.CodeFavoriteFoods");
            DropForeignKey("dbo.EmployeeFovoriteFoods", "Employees_Id", "dbo.Employees");
            DropTable("dbo.CodeFavoriteFoods");
            DropTable("dbo.EmployeeFovoriteFoods");
            CreateIndex("dbo.FovoriteFoods", "Employees_Id");
            AddForeignKey("dbo.FovoriteFoods", "Employees_Id", "dbo.Employees", "Id");
        }
    }
}
