using System;

namespace Rallip.DTOs
{
    public class AlquilerDTO
    {
        public int Id { get; set; }
        public string Inquilino { get; set; }
        public decimal MontoAlquiler { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Estado { get; set; }
    }
}