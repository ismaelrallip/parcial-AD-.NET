using Rallip.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rallip.Application.Services
{
    public interface IAlquilerService 
    {
        Task<List<AlquilerDTO>> ObtenerPorEstadoAsync(string estado);
        Task AgregarAsync(AlquilerDTO dto);
        Task FinalizarAsync(int id);
    }
}