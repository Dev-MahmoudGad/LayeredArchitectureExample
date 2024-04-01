using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Test.Web.Common;
using Test.Web.Services;

namespace Test.Web.Pages.Employee
{
    public class IndexModel : PageModelBase
    {
        public IEnumerable<CustomEmployeeDTO> Employees { get; set; }
        public async Task OnGet()
        {
            var data = await client.GetAllEmployeesAsync();
            Employees = data;
        }

        public async Task OnPostSearchEmployee(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                Employees = await client.SearchEmployeeAsync(name);
            }
            else
            {
                Employees = await client.GetAllEmployeesAsync();
            }
        }

        public async Task OnGetDownload(int id)
        {
            var data = client.DownloadFileAsync(id);
        }

        //public async Task<IActionResult> DownloadFile(int id)
        //{
        //    var file = client.DownloadFileAsync(id);
        //    var filepath = Path.Combine(Directory.GetCurrentDirectory(), "Uploads\\Files", file.Filename);
        //    MemoryStream memoryStream = new();
        //    using FileStream fileStream = new(filepath, FileMode.Open);
        //    fileStream.CopyTo(memoryStream);
        //    memoryStream.Position = 0;
        //    return await File(memoryStream, file.FileData, file.Filename);
        //}

    }
}
