
using System.Text.Json;

namespace ProyectoDePractica.Client.Servicios
{
    public class HttpService : IHttpService
    {
        private HttpClient _http;

        public HttpService(HttpClient http)
        {
            _http = http;
        }

        public async Task<HttpResponse<T>> Get<T>(string url)
        {
            var response = await _http.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var respuesta = await Deserializar<T>(response);
                return new HttpResponse<T>(respuesta, false, response);

            }
            else
            {
                return new HttpResponse<T>(default, true, response);
            }
        }

        private async Task<T?> Deserializar<T>(HttpResponseMessage response)
        {
            var responseSTR = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(responseSTR,
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
    }
}
