using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SampleMosh.Models
{
    public class Department
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Department should not be more than 50 characters")]
        public string DepartmentName { get; set; }

        [MaxLength(200, ErrorMessage = "Department Description should not be more than 200 characters")]
        public string Description { get; set; }
    }
}