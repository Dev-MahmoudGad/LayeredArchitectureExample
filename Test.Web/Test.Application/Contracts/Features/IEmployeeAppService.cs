using Test.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Application.Contracts.Features
{
    public interface IEmployeeAppService
    {
        public Task<IReadOnlyList<CustomEmployeeDTO>> GetAllAsync();
        public Task<IEnumerable<CustomEmployeeDTO>> SearchAsync(string name);
        public Task<EmployeeDTO> GetByID(int ID);
        public Task<EmployeeDTO> AddAsync(EmployeeDTO Obj);
        public Task<EmployeeDTO> UpdateAsync(EmployeeDTO Obj);
        public Task<EmployeeDTO> DeleteAsync(int ID);
        public Task<int> GetMaxId();
        public Task DownloadFileById(int fileName);

    }
}
