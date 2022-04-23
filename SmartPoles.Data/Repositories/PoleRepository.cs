using Microsoft.EntityFrameworkCore;
using SmartPoles.Domain.Entities;
using SmartPoles.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartPoles.Data.Repositories
{
    public class PoleRepository : BaseRepository<Pole>, IPoleRepository
    {
        private readonly SmartPolesContext _context;
        public PoleRepository(SmartPolesContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Pole>> GetPolesByCondominiumIdAsync(Guid condominiumUd)
        {
            return await _context.Poles.Where(pole => pole.CondominiumId == condominiumUd).ToListAsync();
        }

        public async Task<IEnumerable<Pole>> GetPolesWithCondominiumAsync()
        {
            return await _context.Poles.Include(p => p.Condominium).OrderBy(p => p.Condominium.Name).ToListAsync();
        }
    }
}
