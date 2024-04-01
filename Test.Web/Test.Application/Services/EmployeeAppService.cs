using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Application.Contracts.Features;
using Test.Application.Contracts.Persistance;
using Test.Application.DTO;
using Test.Domain.Entities;

namespace Test.Application.Services
{
    public class EmployeeAppService : IEmployeeAppService
    {
        private readonly IAsyncRepository<Employee> iRep;
        private readonly IAsyncRepository<Department> departmentRep;
        private IMapper mapper;
        public EmployeeAppService(IAsyncRepository<Employee> iRep, IAsyncRepository<Department> departmentRep, IMapper mapper)
        {
            this.iRep = iRep;
            this.departmentRep = departmentRep;
            this.mapper = mapper;
        }

        public async Task<EmployeeDTO> AddAsync(EmployeeDTO Obj)
        {
            try
            {
                bool IsSaveFilesToDatabase = false;
                Employee NewObj = new()
                {
                    Name = Obj.Name,
                    Email = Obj.Email,
                    Salary = Obj.Salary,
                    DepartmentId = Obj.DepartmentId,
                    Filename = String.IsNullOrEmpty(Obj.fileData.FileName) ? "" : Obj.fileData.FileName,
                    FileType = Obj.fileType == null ? 0 : Obj.fileType
                };

                if (IsSaveFilesToDatabase && Obj.fileData != null)
                {
                    using (var stream = new MemoryStream())
                    {
                        Obj.fileData.CopyTo(stream);
                        NewObj.FileData = stream.ToArray();
                    }
                }

                else
                {
                    var pathBuilt = Path.Combine(Directory.GetCurrentDirectory(), "Uploads\\Files");
                    if (!Directory.Exists(pathBuilt))
                    {
                        Directory.CreateDirectory(pathBuilt);
                    }
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "Uploads\\Files", Obj.fileData.FileName);
                    using FileStream fileStream = new(path, FileMode.Create);
                    await Obj.fileData.CopyToAsync(fileStream);
                }

                var data = await iRep.AddAsync(NewObj);
                return mapper.Map<EmployeeDTO>(data);
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public async Task<EmployeeDTO> DeleteAsync(int ID)
        {
            var data = await iRep.DeleteAsync(ID);
            return mapper.Map<EmployeeDTO>(data);
        }

        public async Task<IReadOnlyList<CustomEmployeeDTO>> GetAllAsync()
        {
            var empQueryable = await iRep.GetAllAsync();
            var depQueryable = await departmentRep.GetAllAsync();
            var query = from emp in empQueryable
                        join dep in depQueryable
                        on emp.DepartmentId equals dep.Id
                        select new CustomEmployeeDTO
                        {
                            Id = emp.Id,
                            Name = emp.Name,
                            Email = emp.Email,
                            Salary = emp.Salary,
                            DepartmentName = dep.DepartmentName
                        };
            var res = query.ToList();
            return mapper.Map<IReadOnlyList<CustomEmployeeDTO>>(res);
        }

        public async Task<EmployeeDTO> GetByID(int ID)
        {
            var data = await iRep.GetByID(ID);
            //MemoryStream stream = new(data.FileData);
            //FormFile file = new (stream, 0, data.FileData.Length, data.Filename, data.Filename);
            EmployeeDTO Emp = new()
            {
                Name = data.Name,
                Email = data.Email,
                Salary = data.Salary,
                DepartmentId = data.DepartmentId,
                Filename = data.Filename,
                fileType = data.FileType,
                //fileData = file
            };
            return Emp;
        }

        public async Task<int> GetMaxId()
        {
            return await iRep.GetMaxId();
        }

        public async Task<IEnumerable<CustomEmployeeDTO>> SearchAsync(string name)
        {
            var empQueryable = await iRep.GetAllAsync();
            var depQueryable = await departmentRep.GetAllAsync();
            var query = from emp in empQueryable
                        join dep in depQueryable
                        on emp.DepartmentId equals dep.Id
                        select new CustomEmployeeDTO
                        {
                            Id = emp.Id,
                            Name = emp.Name,
                            Email = emp.Email,
                            Salary = emp.Salary,
                            DepartmentName = dep.DepartmentName,
                            Filename=emp.Filename,
                            fileType=emp.FileType,  
                        };
            var res = query.Where(a => a.Name.ToLower().Contains(name.ToLower()) || a.DepartmentName.ToLower().Contains(name.ToLower())).ToList();
            return mapper.Map<IReadOnlyList<CustomEmployeeDTO>>(res);
        }

        public async Task<EmployeeDTO> UpdateAsync(EmployeeDTO Obj)
        {
            var NewObj = mapper.Map<Employee>(Obj);
            var data = await iRep.UpdateAsync(NewObj);
            return mapper.Map<EmployeeDTO>(data);
        }


        public async Task DownloadFileById(int Id)
        {
            try
            {
                var file = await iRep.GetByID(Id);
                var filepath = Path.Combine(Directory.GetCurrentDirectory(), "Uploads\\Files", file.Filename);
                if (File.Exists(filepath))
                {
                    MemoryStream memoryStream = new System.IO.MemoryStream(file.FileData);
                    using FileStream fileStream = new(filepath, FileMode.Open);
                    await fileStream.CopyToAsync(memoryStream);
                }
                var content = new System.IO.MemoryStream(file.FileData);
                var path = Path.Combine(Directory.GetCurrentDirectory(), "FileDownloaded", file.Filename);
                await CopyStream(content, path);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task CopyStream(Stream stream, string downloadPath)
        {
            using (var fileStream = new FileStream(downloadPath, FileMode.Create, FileAccess.Write))
            {
                await stream.CopyToAsync(fileStream);
            }
        }

    }
}
