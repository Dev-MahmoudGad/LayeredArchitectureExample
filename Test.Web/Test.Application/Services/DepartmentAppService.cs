using AutoMapper;
using Test.Application.Contracts.Features;
using Test.Application.Contracts.Persistance;
using Test.Application.DTO;
using Test.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Application.Services
{
    public class DepartmentAppService : IDepartmentAppService
    {
        private readonly IAsyncRepository<Department> iRep;
        private IMapper mapper;
        public DepartmentAppService(IAsyncRepository<Department> iRep, IMapper mapper)
        {
            this.iRep = iRep;
            this.mapper = mapper;
        }

        public async Task<DepartmentDTO> AddAsync(DepartmentDTO Obj)
        {
            var NewObj = mapper.Map<Department>(Obj);
            var data = await iRep.AddAsync(NewObj);
            return mapper.Map<DepartmentDTO>(data);
        }

        public async Task<DepartmentDTO> DeleteAsync(DepartmentDTO Obj)
        {
            var NewObj = mapper.Map<Department>(Obj);
            var data = await iRep.DeleteAsync(NewObj);
            return mapper.Map<DepartmentDTO>(data);
        }

        public async Task<DepartmentDTO> DeleteAsync(int ID)
        {
            var data = await iRep.DeleteAsync(ID);
            return mapper.Map<DepartmentDTO>(data);
        }

        public async Task<IReadOnlyList<DepartmentDTO>> GetAllAsync()
        {
            return mapper.Map<IReadOnlyList<DepartmentDTO>>(await iRep.GetAllAsync());
        }

        public async Task<DepartmentDTO> GetByID(int ID)
        {
            var data = await iRep.GetByID(ID);


            return mapper.Map<DepartmentDTO>(data);
        }

        public Task<int> GetMaxId()
        {
            throw new NotImplementedException();
        }

        public async Task<DepartmentDTO> UpdateAsync(DepartmentDTO Obj)
        {
            var NewObj = mapper.Map<Department>(Obj);
            var data = await iRep.UpdateAsync(NewObj);
            return mapper.Map<DepartmentDTO>(data);
        }
    }
}
