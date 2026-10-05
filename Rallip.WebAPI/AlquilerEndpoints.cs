using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Rallip.Application.Services;
using Rallip.DTOs;
using System;

namespace Rallip.WebAPI
{
    public static class AlquilerEndpoints
    {
        public static void MapAlquilerEndpoints(this IEndpointRouteBuilder app)
        {
            // Agrupamos las rutas bajo el prefijo exacto
            var group = app.MapGroup("/api/alquileres");

            // a. Recuperar registros según el estado
            group.MapGet("/{estado}", async (string estado, IAlquilerService service)  =>
            {
                var result = await service.ObtenerPorEstadoAsync(estado);
                return Results.Ok(result);
            });

            // b. Agregar nuevo registro (el post apunta a la raíz del grupo "/")
            group.MapPost("/", async (AlquilerDTO dto, IAlquilerService service) =>
            {
                try
                {
                    await service.AgregarAsync(dto);
                    return Results.Ok();
                }
                catch (ArgumentException ex)
                {
                    // Atrapa errores de validación (Monto, Fechas, etc.)
                    return Results.BadRequest(ex.Message);
                }
                catch (Exception ex)
                {
                    // Atrapa errores de base de datos o servidor sin cortar la conexión
                    return Results.Problem($"Error interno del servidor: {ex.InnerException?.Message ?? ex.Message}");
                }
            });

            // c. Finalizar un Alquiler
            group.MapPut("/finalizar/{id}", async (int id, IAlquilerService service) =>
            {
                try
                {
                    await service.FinalizarAsync(id);
                    return Results.Ok();
                }
                catch (Exception ex)
                {
                    return Results.Problem($"Error al finalizar: {ex.Message}");
                }
            });
        }
    }
}