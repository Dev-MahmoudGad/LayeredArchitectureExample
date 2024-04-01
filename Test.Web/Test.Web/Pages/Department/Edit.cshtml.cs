using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Test.Web.Common;
using Test.Web.Services;


namespace Test.Web.Pages.Department
{
    public class EditModel : PageModelBase
    {
        public DepartmentDTO Department { get; set; }
        public void OnGet(int Id)
        {
            var data = client.IDAsync(Id);
            Department = data.Result;
        }

        public async Task<IActionResult> OnPost(DepartmentDTO dep)
        {
            var data = await client.UpdateDepartmentAsync(dep);
            return RedirectToPage("Index");
        }
    }
}
