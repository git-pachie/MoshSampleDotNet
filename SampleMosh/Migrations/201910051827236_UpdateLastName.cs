namespace SampleMosh.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateLastName : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "LastName", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "LastName", c => c.String());
        }
    }
}
