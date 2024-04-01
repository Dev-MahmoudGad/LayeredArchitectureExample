using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Test.Web.Common;
using Test.Web.Services;

namespace Test.Web.Pages.Department
{
    public class IndexModel : PageModelBase
    {
        public IEnumerable<DepartmentDTO> Departments { get; set; }
        public async Task OnGet()
        {
            var data = await client.GetAllDepartmentsAsync();
            Departments = data;
        }


    }
}
