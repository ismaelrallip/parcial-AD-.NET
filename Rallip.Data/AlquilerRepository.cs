using Microsoft.EntityFrameworkCore;
using Rallip.Domain.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rallip.Data
{
    public class AlquilerRepository : IAlquilerRepository
    {
        private readonly TPIContext _context;

        public AlquilerRepository(TPIContext context)
        {
            _context = context;
        }

        public async Task<List<Alquiler>> GetByEstadoAsync(string estado)
        {
            return await _context.Alquileres.Where(a => a.Estado == estado).ToListAsync();
        }

        public async Task<Alquiler> GetByIdAsync(int id)
        {
            return await _context.Alquileres.FindAsync(id);
        }

        public async Task AddAsync(Alquiler alquiler)
        {
            await _context.Alquileres.AddAsync(alquiler);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Alquiler alquiler)
        {
            _context.Alquileres.Update(alquiler);
            await _context.SaveChangesAsync();
        }
    }
}