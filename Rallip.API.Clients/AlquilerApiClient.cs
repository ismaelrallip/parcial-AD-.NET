using Rallip.DTOs;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Rallip.API.Clients
{
    public class AlquilerApiClient : BaseApiClient
    {
        public async Task<List<AlquilerDTO>> GetAlquileresAsync(string estado)
        {
            return await _http.GetFromJsonAsync<List<AlquilerDTO>>($"api/alquileres/{estado}");
        }

        public async Task<string> AddAlquilerAsync(AlquilerDTO dto)
        {
            try
            {
                // Petición con la barra al final
                var response = await _http.PostAsJsonAsync("api/alquileres/", dto);

                if (!response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }

                return null; // Todo OK
            }
            catch (Exception ex)
            {
                // Si se corta la conexión, devolvemos el error sin que explote la app
                return $"Error de conexión con la API: {ex.Message}";
            }
        }

        public async Task FinalizarAlquilerAsync(int id)
        {
            await _http.PutAsync($"api/alquileres/finalizar/{id}", null);
        }
    }
}