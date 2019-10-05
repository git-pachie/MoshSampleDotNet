namespace SampleMosh.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateEmployees : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "CreatedBy", c => c.String(maxLength: 25));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "CreatedBy", c => c.String());
        }
    }
}
