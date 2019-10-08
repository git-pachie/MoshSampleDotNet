using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleMosh.Models
{
    public class EmployeeFavoriteFood
    {
        public int Id { get; set; }
        
        public Employee Employees { get; set; }

        public int EmployeeId { get; set; }

        //public CodeFavoriteFood CodeFovoriteFood { get; set; }

        public int  CodeFavoriteId { get; set; }
    }
}