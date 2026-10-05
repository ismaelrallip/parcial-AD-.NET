using Rallip.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rallip.Data
{
    public interface IAlquilerRepository
    {
        Task<List<Alquiler>> GetByEstadoAsync(string estado);
        Task<Alquiler> GetByIdAsync(int id);
        Task AddAsync(Alquiler alquiler);
        Task UpdateAsync(Alquiler alquiler);
    }
}