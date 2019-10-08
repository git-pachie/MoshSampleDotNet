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
        
        public string Name { get; set; }

        [Required]
        [StringLength(50)]

        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public Department Department { get; set; }

        public int DepartmentId { get; set; }
        public DateTime? DateCreated { get; set; }


        [StringLength(25)]
        public string CreatedBy { get; set; }


        public DateTime? LastDateModified { get; set; }


        public string LastModifiedBy { get; set; }

        public List<EmployeeFavoriteFood> FavoriteFoods { get; set; }

       // public List<int> EmployeeFovoriteFood { get; set; }
    }
}