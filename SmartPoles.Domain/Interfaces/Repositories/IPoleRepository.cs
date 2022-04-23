using SmartPoles.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartPoles.Domain.Interfaces.Repositories
{
    public interface IPoleRepository : IBaseRepository<Pole>
    {
        Task<IEnumerable<Pole>> GetPolesByCondominiumIdAsync(Guid condominiumUd);
        Task<IEnumerable<Pole>> GetPolesWithCondominiumAsync();
    }
}
