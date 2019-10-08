namespace SampleMosh.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEmployeeFovoriteFood : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "LastModifiedBy", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "LastModifiedBy", c => c.String(maxLength: 25));
        }
    }
}
