using SampleMosh.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SampleMosh.Dto
{
    public class EmployeeDto
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

        public List<EmployeeFavoriteFood> FavoriteFoods { get; set; }
    }
}