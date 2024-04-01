
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Domain.Entities;
using Test.Domain.Enums;
using Test.Localization;

namespace Test.Application.DTO
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        [MinLength(6)]
        //[Required(ErrorMessage = null, ErrorMessageResourceName = "RequiredFieldMessage", ErrorMessageResourceType = typeof(Resource))]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter Salary")]
        [Range(1000, 2000, ErrorMessage = "Salary should be range Between 1000 and 2000")]
        public decimal Salary { get; set; }
        public string Email { get; set; }
        public int DepartmentId { get; set; }
        public string? Filename { get; init; }

        public IFormFile? fileData { get; set; }
        public FileType? fileType { get; set; }

    }
}
