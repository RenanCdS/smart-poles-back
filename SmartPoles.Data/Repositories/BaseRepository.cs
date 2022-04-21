using Microsoft.EntityFrameworkCore;
using SmartPoles.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartPoles.Data.Repositories
{
    public class BaseRepository<T> where T : Base
    {
        private readonly SmartPolesContext _context;
        public BaseRepository(SmartPolesContext context)
        {
            _context = context;
        }
        public async Task AddAsync(T entity)
        {
           await _context.AddAsync(entity);
           await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _context.FindAsync<T>(id);
            if (entity is null)
                return;
            _context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(entity => entity.Id == id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }
    }
}
