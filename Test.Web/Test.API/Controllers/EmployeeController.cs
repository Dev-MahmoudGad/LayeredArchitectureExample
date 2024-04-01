using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test.Application.Contracts.Features;
using Test.Application.DTO;

namespace Test.API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private readonly IEmployeeAppService employeeAppService;
        public EmployeeController(IEmployeeAppService employeeAppService)
        {
            this.employeeAppService = employeeAppService;
        }

        [HttpGet]
        public async Task<IEnumerable<CustomEmployeeDTO>> GetAllEmployees()
        {
            var data = await employeeAppService.GetAllAsync();
            return data;
        }

        [HttpGet("ID")]
        public async Task<EmployeeDTO> GetEmployeeByID(int ID)
        {
            var data = await employeeAppService.GetByID(ID);
            return data;
        }

        [HttpPost]
        public async Task<EmployeeDTO> AddEmployee([FromForm] EmployeeDTO EmployeeDTO)
        {
            var data = await employeeAppService.AddAsync(EmployeeDTO);
            return data;
        }

        [HttpDelete]
        public async Task<EmployeeDTO> DeleteEmployeeByID(int ID)
        {
            var data = await employeeAppService.DeleteAsync(ID);
            return data;
        }

        [HttpGet("SearchEmployee")]
        public async Task<IEnumerable<CustomEmployeeDTO>> SearchEmployees(string name)
        {
            return await employeeAppService.SearchAsync(name);
        }

        [HttpPut]
        public async Task<EmployeeDTO> UpdateEmployee(EmployeeDTO EmployeeGetDTO)
        {
            var data = await employeeAppService.UpdateAsync(EmployeeGetDTO);
            return data;
        }


        [HttpGet("DownloadFile")]
        public async Task<ActionResult> DownloadFile(int id)
        {

            try
            {
                await employeeAppService.DownloadFileById(id);
                return Ok();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }

}

