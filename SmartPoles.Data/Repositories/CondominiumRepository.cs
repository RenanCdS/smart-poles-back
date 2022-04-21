using SmartPoles.Domain.Interfaces.Repositories;
using SmartPoles.Domain.Entities;

namespace SmartPoles.Data.Repositories
{
    public class CondominiumRepository : BaseRepository<Condominium>, ICondominiumRepository
    {
        private readonly SmartPolesContext _context;
        public CondominiumRepository(SmartPolesContext context) : base(context)
        {
            _context = context;
        }
    }
}
