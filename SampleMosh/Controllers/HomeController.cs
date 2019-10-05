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
            var model = new ViewModels.EmployeeFormViewModel
            {
                Employee = employee,
                Departments = _context.Departments.ToList()
            };

            return View(model);
        }



    }
}