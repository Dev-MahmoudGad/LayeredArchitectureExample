using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Domain.Enums;

namespace Test.Application.DTO
{
    public class CustomEmployeeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public string Email { get; set; }
        public string DepartmentName { get; set; }
        public string? Filename { get; init; }

        public IFormFile? fileData { get; set; }
        public FileType? fileType { get; set; }
    }
}
