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

            var employee = new Dto.EmployeeDto(){ Id = 0 };

            var model = new ViewModels.EmployeeFormViewModel(_context)
            {
                Employee = employee
                , Title = "Create New Employee"

            };

            return View(model);
        }

        [HttpPost]
        public ActionResult CreateEmployee(ViewModels.EmployeeFormViewModel vm)
        {
           

            var selecteFoodList = new List<EmployeeFavoriteFood>();


            if (vm.Employee.Id == 0)
            {

                var newEmployee = new Models.Employee {
                     Id = 0
                     , Name = vm.Employee.Name
                     , LastName = vm.Employee.LastName
                     , BirthDate = vm.Employee.BirthDate
                     , DepartmentId = vm.Employee.DepartmentId
                     , DateCreated = DateTime.Now
                     , CreatedBy = "Admin"

                };

                

                _context.Employees.Add(newEmployee);

                foreach (var itm in vm.FavoriteFoodDtos.Where(x => x.IsSelected == true))
                {
                    _context.EmployeeFovoriteFoods.Add(new EmployeeFavoriteFood { Employees = newEmployee, CodeFavoriteId = itm.SelectedId });
                }

            }
            else
            {
                var result = _context.Employees
                    .Include(o=> o.FavoriteFoods)
                    .SingleOrDefault(x => x.Id == vm.Employee.Id);

                result.Name = vm.Employee.Name;
                result.LastName = vm.Employee.LastName;
                result.DepartmentId = vm.Employee.DepartmentId;
                result.BirthDate = vm.Employee.BirthDate;
                result.LastDateModified = DateTime.Now;
                result.LastModifiedBy = "Admin";

                _context.EmployeeFovoriteFoods
                    .RemoveRange(_context.EmployeeFovoriteFoods.Where(x => x.EmployeeId == result.Id)
                    .ToList());

                foreach (var itm in vm.FavoriteFoodDtos.Where(x => x.IsSelected == true))
                {
                    _context.EmployeeFovoriteFoods.Add(new EmployeeFavoriteFood { Employees = result, CodeFavoriteId = itm.SelectedId });
                }


                //get the 



            }



            _context.SaveChanges();

            var lsFoods = new List<Dto.CodeFavoriteFoodDTO>();

            //foreach (var item in _context.CodeFavoriteFoods)
            //{
            //    lsFoods.Add(new Dto.CodeFavoriteFoodDTO
            //    {
            //        FavoriteFoodName = item.FoodName
            //    ,
            //        SelectedId = false
            //    });
            //}




            var model = new ViewModels.EmployeeFormViewModel(_context)
            {
                Employee = vm.Employee

            };


            return View(model);
        }

        public ActionResult EditEmployee(int id)
        {
            var result = _context.Employees
                .SingleOrDefault(x => x.Id == id);

            if(result == null)
            {
                return new HttpNotFoundResult();
            }

            var model = new ViewModels.EmployeeFormViewModel(_context, result)
            {
                Employee = new Dto.EmployeeDto { Id = result.Id, Name = result.Name, LastName = result.LastName, BirthDate = result.BirthDate, Department = result.Department, DepartmentId = result.DepartmentId, FavoriteFoods = result.FavoriteFoods }
            };



            return View("CreateEmployee", model);



        }



    }
}