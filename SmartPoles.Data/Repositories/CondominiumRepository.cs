using SmartPoles.Domain.Interfaces.Repositories;
using SmartPoles.Domain.Entities;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;

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
