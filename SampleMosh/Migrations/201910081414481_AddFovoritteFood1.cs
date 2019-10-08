namespace SampleMosh.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFovoritteFood1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.FovoriteFoods", "IsSelected");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FovoriteFoods", "IsSelected", c => c.Boolean(nullable: false));
        }
    }
}
