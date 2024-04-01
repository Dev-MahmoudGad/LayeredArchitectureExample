using Test.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Application.Contracts.Features
{
    public interface IDepartmentAppService
    {
        public Task<IReadOnlyList<DepartmentDTO>> GetAllAsync();
        public Task<DepartmentDTO> GetByID(int ID);
        public Task<DepartmentDTO> AddAsync(DepartmentDTO Obj);
        public Task<DepartmentDTO> UpdateAsync(DepartmentDTO Obj);
        public Task<DepartmentDTO> DeleteAsync(DepartmentDTO Obj);
        public Task<DepartmentDTO> DeleteAsync(int ID);
        public Task<int> GetMaxId();

    }
}
