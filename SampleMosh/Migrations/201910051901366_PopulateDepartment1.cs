namespace SampleMosh.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateDepartment1 : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO [dbo].[Departments] ([DepartmentName], [Description])  VALUES ('Human Resources','HR' )");
            Sql("INSERT INTO [dbo].[Departments] ([DepartmentName], [Description])  VALUES ('Operations', 'OPS' )");
            Sql("INSERT INTO [dbo].[Departments] ([DepartmentName], [Description])  VALUES ('Finance','Finance Department' )");
            Sql("INSERT INTO [dbo].[Departments] ([DepartmentName], [Description])  VALUES ('Information Technology', 'IT Department' )");
            Sql("INSERT INTO [dbo].[Departments] ([DepartmentName], [Description])  VALUES ('Credit', 'Credit or Risk Dept' )");
            Sql("INSERT INTO [dbo].[Departments] ([DepartmentName], [Description])  VALUES ('Retail Broking', 'Retail' )");
            Sql("INSERT INTO [dbo].[Departments] ([DepartmentName], [Description])  VALUES ('Compliance','Compliance '  )");
            Sql("INSERT INTO [dbo].[Departments] ([DepartmentName], [Description])  VALUES ('Research', 'Research' )");
        }
        
        public override void Down()
        {
        }
    }
}
