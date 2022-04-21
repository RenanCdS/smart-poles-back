using SmartPoles.Domain.Entities;
using SmartPoles.Domain.Interfaces.Repositories;

namespace SmartPoles.Data.Repositories
{
    public class PoleRepository : BaseRepository<Pole>, IPoleRepository
    {
        private readonly SmartPolesContext _context;
        public PoleRepository(SmartPolesContext context) : base(context)
        {
            _context = context;
        }
    }
}
