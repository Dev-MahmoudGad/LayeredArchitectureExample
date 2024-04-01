using AutoMapper;
using Test.Application.DTO;
using Test.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Application
{
    public class ApplicationAutoMapperProfile:Profile
    {
        public ApplicationAutoMapperProfile()
        {
            CreateMap<Department, DepartmentDTO>().ReverseMap();
            CreateMap<Employee, EmployeeDTO>().ReverseMap();
        }
    }
}
