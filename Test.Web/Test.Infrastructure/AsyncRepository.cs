using Microsoft.EntityFrameworkCore;
using Test.Application.Contracts.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Infrastructure;

namespace Test.Infrastructure
{
    public class AsyncRepository<t>: IAsyncRepository<t> where t:class
    {
        private readonly PetrobelAppContext DbContext;
        public AsyncRepository(PetrobelAppContext DbContext)
        {
            this.DbContext = DbContext;
        }

        public async Task<t> AddAsync(t Obj)
        {
            await DbContext.Set<t>().AddAsync(Obj);
            await DbContext.SaveChangesAsync();
            return Obj;
        }

        public async Task<t> DeleteAsync(t Obj)
        {
            DbContext.Set<t>().Remove(Obj);
            await DbContext.SaveChangesAsync();
            return Obj;
        }

        public async Task<t> DeleteAsync(int ID)
        {
            t Obj = await DbContext.Set<t>().FindAsync(ID);
            DbContext.Remove(Obj);
            await DbContext.SaveChangesAsync();
            return Obj;
        }

        public async Task<IReadOnlyList<t>> GetAllAsync()
        {
            return await DbContext.Set<t>().ToListAsync();
        }

        public async Task<IQueryable<t>> GetAllAsNoTracking()
        {
            return DbContext.Set<t>().AsNoTracking();
        }

        public async Task<t> GetByID(int ID)
        {
            return await DbContext.Set<t>().FindAsync(ID);
        }

        public Task<int> GetMaxId()
        {
             //DbContext.Set<t>().Max();
            throw new NotImplementedException();
        }

        public async Task<t> UpdateAsync(t Obj)
        {
            DbContext.Attach(Obj);
            var updatedEntity = DbContext.Update(Obj).Entity;
            await DbContext.SaveChangesAsync();
            return updatedEntity;
        }
    }
}
