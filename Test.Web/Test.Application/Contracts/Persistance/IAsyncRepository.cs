using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Application.Contracts.Persistance
{
    public interface IAsyncRepository<T>
    {
        public Task<IQueryable<T>> GetAllAsNoTracking();
        public Task<IReadOnlyList<T>> GetAllAsync();
        public Task<T> GetByID(int ID);
        public Task<T> AddAsync(T Obj);
        public Task<T> UpdateAsync(T Obj);
        public Task<T> DeleteAsync(T Obj);
        public Task<T> DeleteAsync(int ID);
        public Task<int> GetMaxId();

    }
}
