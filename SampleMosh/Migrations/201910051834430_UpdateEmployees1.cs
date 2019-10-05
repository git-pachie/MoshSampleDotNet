namespace SampleMosh.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateEmployees1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "LastDateModified", c => c.DateTime());
            AddColumn("dbo.Employees", "LastModifiedBy", c => c.String(maxLength: 25));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "LastModifiedBy");
            DropColumn("dbo.Employees", "LastDateModified");
        }
    }
}
