using SmartPoles.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartPoles.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetUserByUsernameAsync(string username);
        Task<IEnumerable<User>> GetAllUsersWithCondominiumAsync();
    }
}
