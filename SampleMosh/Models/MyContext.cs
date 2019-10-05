using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SampleMosh.Models
{
    public class MyContext : DbContext
    {
        public MyContext() : base("name=MyEntDBConnectionString")
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}