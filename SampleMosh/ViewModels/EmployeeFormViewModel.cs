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

        public List<Dto.CodeFavoriteFoodDTO> FavoriteFoodDtos { get; set; }

        public EmployeeFormViewModel()
        {
                
        }

        MyContext _context;
        public EmployeeFormViewModel(MyContext dbcontext)
        {
            _context = dbcontext;


            Departments = _context.Departments
                .ToList();

            FavoriteFoodDtos = new List<Dto.CodeFavoriteFoodDTO>();

            foreach(var itm in _context.CodeFavoriteFoods)
            {
                FavoriteFoodDtos.Add(
                    new Dto.CodeFavoriteFoodDTO { FavoriteFoodName = itm.FoodName, IsSelected = false, SelectedId = itm.id }
                    );
            }
                
        }
        public EmployeeFormViewModel(MyContext dbcontext, Employee employee)
        {
            _context = dbcontext;

            Departments = _context.Departments.ToList();

            FavoriteFoodDtos = new List<Dto.CodeFavoriteFoodDTO>();


            var empFoods = _context.EmployeeFovoriteFoods.Where(x => x.EmployeeId == employee.Id).ToList();

            foreach (var itm in _context.CodeFavoriteFoods)
            {
                
                FavoriteFoodDtos.Add(new Dto.CodeFavoriteFoodDTO { FavoriteFoodName = itm.FoodName, IsSelected = false, SelectedId = itm.id });
            }

            //update values
            foreach(var itm in FavoriteFoodDtos)
            {
                foreach(var d in empFoods.Where(x=> x.CodeFavoriteId == itm.SelectedId))
                {
                    itm.IsSelected = true;

                }

            }
            


        }
    }
}