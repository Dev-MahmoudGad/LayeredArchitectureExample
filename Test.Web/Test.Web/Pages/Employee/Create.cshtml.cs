using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Globalization;
using Test.Web.Common;
using Test.Web.Services;

namespace Test.Web.Pages.Employee
{
    public class CreateModel : PageModelBase
    {
        [BindProperty]
        public IEnumerable<DepartmentDTO> Departments { get; set; }
        public IEnumerable<EmployeeDTO> Employees { get; set; }

        [BindProperty]
        public EmployeeDTO EmployeeDTO { get; set; }

        public async Task OnGet()
        {
            Departments = await client.GetAllDepartmentsAsync();
            ViewData["departmentId"] = Departments.Select(a => new SelectListItem(){Value = a.Id.ToString(),Text = a.DepartmentName}).ToList();
        }

        public async Task<IActionResult> OnPostCreate(EmployeeDTO emp)
        {
            if (!ModelState.IsValid) return Page();
            //var data = await client.AddEmployeeAsync(emp);
            return RedirectToPage("Index");
        }
    }
}
