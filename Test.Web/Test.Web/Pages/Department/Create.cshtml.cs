using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Test.Web.Common;
using Test.Web.Services;

namespace Test.Web.Pages.Department
{
    public class CreateModel : PageModelBase
    {
        public IEnumerable<DepartmentDTO> Departments { get; set; } 

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost(DepartmentDTO dep)
        {
            var data = await client.AddDepartmentAsync(dep);
            return RedirectToPage("Index");
        }
    }
}
