using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Automapper
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new MapperConfiguration(cfg =>
            {

                cfg.CreateMap<Models.Employee, DTO.EmployeeDTO>()
                .ForMember(d=> d.GivenAge, opts=> opts.MapFrom(src=> src.Age))
                .ReverseMap();

            });


            // only during development, validate your mappings; remove it before release
            //configuration.AssertConfigurationIsValid();
            // use DI (http://docs.automapper.org/en/latest/Dependency-injection.html) or create the mapper yourself
            var mapper = config.CreateMapper();


            var empData = new Models.Employee
            {
                PersonId = Guid.NewGuid().ToString()
                 ,
                Name = "Archie"
                 ,
                LastName = "Angeles"

                , Age = 30

            };


            var map = mapper.Map<DTO.EmployeeDTO>(empData);

            var map2 = mapper.Map<Models.Employee>(map);


        }
    }
}
