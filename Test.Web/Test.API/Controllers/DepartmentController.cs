using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test.Application.Contracts.Features;
using Test.Application.DTO;

namespace Test.API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentAppService DepartmentAppService;

        public DepartmentController(IDepartmentAppService departmentAppService)
        {
            this.DepartmentAppService = departmentAppService;
        }


        [HttpGet]
        public async Task<IEnumerable<DepartmentDTO>> GetAllDepartments()
        {
            var data = await DepartmentAppService.GetAllAsync();
            return data;
        }

        [HttpGet("ID")]
        public async Task<DepartmentDTO> GetDepartmentByID(int ID)
        {
            var data = await DepartmentAppService.GetByID(ID);
            return data;
        }

        [HttpPost]
        public async Task<DepartmentDTO> AddDepartment(DepartmentDTO departmentDTO)
        {
            var data = await DepartmentAppService.AddAsync(departmentDTO);
            return data;
        }



        [HttpDelete]
        public async Task<DepartmentDTO> DeleteDepartmentByID(int ID)
        {
            var data = await DepartmentAppService.DeleteAsync(ID);
            return data;
        }


        [HttpPut]
        public async Task<DepartmentDTO> UpdateDepartment(DepartmentDTO departmentGetDTO)
        {
            var data = await DepartmentAppService.UpdateAsync(departmentGetDTO);
            return data;
        }

    }
}
