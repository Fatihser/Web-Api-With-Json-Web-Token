using FSEJwtApp.Back.Core.Application.Interfaces;
using FSEJwtApp.Back.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FSEJwtApp.Back.Persistance.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        private readonly FSEJwtContext _context;

        public Repository(FSEJwtContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(T entity)
        {
            await this._context.Set<T>().AddAsync(entity);
            await this._context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await this._context.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T?> GetByFilerAsync(Expression<Func<T, bool>> filter)
        {
            return await this._context.Set<T>().AsNoTracking().SingleOrDefaultAsync(filter);
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await this._context.Set<T>().FindAsync(id);
        }

        public async Task RemoveAsync(T entity)
        {
            this._context.Set<T>().Remove(entity);
            await this._context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            this._context.Set<T>().Update(entity);
            await this._context.SaveChangesAsync();
        }
    }
}
