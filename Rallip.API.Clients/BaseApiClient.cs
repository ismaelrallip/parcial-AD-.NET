using System;
using System.Net.Http;

namespace Rallip.API.Clients
{
    public abstract class BaseApiClient
    {
        protected readonly HttpClient _http;

        protected BaseApiClient()
        {
            // Cambiamos a HTTP plano en el puerto 5184
            _http = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:5184/")
            };
        }
    }
}