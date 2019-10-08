namespace SampleMosh.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFoodFavorite : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FovoriteFoods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsSelected = c.Boolean(nullable: false),
                        Employee_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.Employee_Id)
                .Index(t => t.Employee_Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.FovoriteFoods", new[] { "Employee_Id" });
            DropForeignKey("dbo.FovoriteFoods", "Employee_Id", "dbo.Employees");
            DropTable("dbo.FovoriteFoods");
        }
    }
}
