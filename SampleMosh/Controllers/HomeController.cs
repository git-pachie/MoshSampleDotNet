using SampleMosh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace SampleMosh.Controllers
{
    public class HomeController : Controller
    {

        private MyContext _context;

        public HomeController()
        {
            _context = new MyContext();
        }

        protected override void Dispose(bool disposing)
        {
            

            _context.Dispose();
        }

        public ActionResult Index()
        {

            var employees = _context.Employees.Include(x => x.Department).ToList();

            return View(employees);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult CreateEmployee()
        {

            var employee = new Models.Employee
            { Id = 0 };

            var model = new ViewModels.EmployeeFormViewModel
            {
                Employee = employee,
                Departments = _context.Departments.ToList()
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult CreateEmployee(Models.Employee employee )
        {
            employee.DateCreated = DateTime.Now;
            employee.CreatedBy = "Admin";

            if(employee.Id == 0)
            {
                _context.Employees.Add(employee);
            }
            else
            {
                var result = _context.Employees.SingleOrDefault(x => x.Id == employee.Id);

                result.Name = employee.Name;
                result.LastName = employee.LastName;
                result.DepartmentId = employee.DepartmentId;
                result.BirthDate = employee.BirthDate;
                result.LastDateModified = DateTime.Now;
                result.LastModifiedBy = "Admin";

            }

            

            _context.SaveChanges();

            var model = new ViewModels.EmployeeFormViewModel
            {
                Employee = employee,
                Departments = _context.Departments.ToList()
            };

            

            

            return View(model);
        }

        public ActionResult EditEmployee(int id)
        {
            var result = _context.Employees.SingleOrDefault(x => x.Id == id);

            var model = new ViewModels.EmployeeFormViewModel
            {
                Employee = result,
                Departments = _context.Departments.ToList()
            };


            return View("CreateEmployee", model);



        }



    }
}