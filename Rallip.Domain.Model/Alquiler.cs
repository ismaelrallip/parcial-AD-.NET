using System;

namespace Rallip.Domain.Model
{
    public class Alquiler
    {
        public int Id { get; set; }
        public string Inquilino { get; set; } 
        public decimal MontoAlquiler { get; set; } 
        public DateTime FechaInicio { get; set; } 
        public DateTime FechaFin { get; set; } 
        public string Estado { get; set; } 
    }
}