using Microsoft.EntityFrameworkCore;
using SmartPoles.Domain.Entities;
using SmartPoles.Domain.Interfaces.Repositories;
using System.Threading.Tasks;

namespace SmartPoles.Data.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly SmartPolesContext _context;
        public UserRepository(SmartPolesContext context) : base(context)
        {
            _context = context;
        }
        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await _context.Users.Include(u => u.Condominium)
                .FirstOrDefaultAsync(user => user.Username == username);
        }
    }
}
