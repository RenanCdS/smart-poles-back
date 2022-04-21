using System;
using System.Threading.Tasks;

namespace SmartPoles.Data.Repositories
{
    public class BaseRepository<T> where T : class
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
            _context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
    }
}
