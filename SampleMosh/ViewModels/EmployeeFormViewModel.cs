using SampleMosh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleMosh.ViewModels
{
    public class EmployeeFormViewModel
    {
        public Employee Employee { get; set; }
        public IEnumerable<Department> Departments { get; set; }
    }
}