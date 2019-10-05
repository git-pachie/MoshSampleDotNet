using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SampleMosh.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [MaxLength(50, ErrorMessage = "Name should not be more that 50 characters")]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        [MaxLength(50, ErrorMessage = "Last Name should not be more that 50 characters")]
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public Department Department { get; set; }

        public int DepartmentId { get; set; }
        public DateTime? DateCreated { get; set; }

        [MaxLength(25, ErrorMessage ="Created by should not exceed 25 characters")]
        [StringLength(25)]
        public string CreatedBy { get; set; }


        public DateTime? LastDateModified { get; set; }


        [MaxLength(25, ErrorMessage = "Last Modified by should not exceed 25 characters")]
        public string LastModifiedBy { get; set; }
    }
}