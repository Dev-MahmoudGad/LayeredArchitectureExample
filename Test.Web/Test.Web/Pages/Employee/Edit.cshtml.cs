using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Test.Web.Common;
using Test.Web.Services;

namespace Test.Web.Pages.Employee
{
    public class EditModel : PageModelBase
    {
        public EmployeeDTO Employee { get; set; }
        public IEnumerable<DepartmentDTO> Departments { get; set; }

        public async Task OnGet(int Id)
        {
            Departments = await client.GetAllDepartmentsAsync();
            ViewData["departmentId"] = Departments.Select(a => new SelectListItem() { Value = a.Id.ToString(), Text = a.DepartmentName }).ToList();

            var data = await client.ID2Async(Id);
            Employee = data;
        }

        public async Task<IActionResult> OnPostEdit(EmployeeDTO dep)
        {
            var data = await client.UpdateEmployeeAsync(dep);
            return RedirectToPage("Index");
        }
    }
}
