using Rallip.Data;
using Rallip.Domain.Model;
using Rallip.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rallip.Application.Services
{
    public class AlquilerService : IAlquilerService
    {
        // 1. Aquí cambiamos a la interfaz
        private readonly IAlquilerRepository _repository;

        // 2. Aquí también inyectamos la interfaz
        public AlquilerService(IAlquilerRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<AlquilerDTO>> ObtenerPorEstadoAsync(string estado)
        {
            var alquileres = await _repository.GetByEstadoAsync(estado);
            return alquileres.Select(a => new AlquilerDTO
            {
                Id = a.Id,
                Inquilino = a.Inquilino,
                MontoAlquiler = a.MontoAlquiler,
                FechaInicio = a.FechaInicio,
                FechaFin = a.FechaFin,
                Estado = a.Estado
            }).ToList();
        }

        public async Task AgregarAsync(AlquilerDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Inquilino))
                throw new ArgumentException("El campo Inquilino es obligatorio.");

            if (dto.MontoAlquiler < 0 || dto.MontoAlquiler > 1000000)
                throw new ArgumentException("El Monto del Alquiler debe estar entre 0 y 1.000.000.");

            if (dto.FechaInicio >= dto.FechaFin)
                throw new ArgumentException("La Fecha de Inicio debe ser inferior a la Fecha de Fin.");

            var alquiler = new Alquiler
            {
                Inquilino = dto.Inquilino,
                MontoAlquiler = dto.MontoAlquiler,
                FechaInicio = dto.FechaInicio,
                FechaFin = dto.FechaFin,
                Estado = "Activo"
            };

            await _repository.AddAsync(alquiler);
        }

        public async Task FinalizarAsync(int id)
        {
            var alquiler = await _repository.GetByIdAsync(id);
            if (alquiler != null && alquiler.Estado == "Activo")
            {
                alquiler.Estado = "Finalizado";
                await _repository.UpdateAsync(alquiler);
            }
        }
    }
}