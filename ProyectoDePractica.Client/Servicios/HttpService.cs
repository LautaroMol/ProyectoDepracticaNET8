
using System.Text;
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
                var respuesta = await Deserialize<T>(response);
                return new HttpResponse<T>(respuesta, false, response);

            }
            else
            {
                return new HttpResponse<T>(default, true, response);
            }
        }

        public async Task<HttpResponse<object>> Post<T>(string url,T entity)
        {
            var sendJson = JsonSerializer.Serialize(entity);

            var sendContent = new StringContent(sendJson, Encoding.UTF8, "application/json");

            var response = await _http.PostAsync(url, sendContent);

            if (response.IsSuccessStatusCode)
            {
                var resp = await Deserialize<object>(response);
                return new HttpResponse<object>(resp, false, response);

            }else return new HttpResponse<object>(default, true, response);

        }

        public async Task<HttpResponse<object>> Put<T>(string url,T entity)
        {
            var sendJson = JsonSerializer.Serialize(entity);
            var sendContent = new StringContent(sendJson, Encoding.UTF8, "application/json");

            var response = await _http.PutAsync(url, sendContent);

            if (response.IsSuccessStatusCode)
            {
                //var resp = await Deserialize<T>(response);
                return new HttpResponse<object>(null, false, response);
            }
            else return new HttpResponse<object>(default, true, response);
        }

        public async Task<HttpResponse<object>> Delete(string url)
        {
            var response = await _http.DeleteAsync(url);
            return new HttpResponse<object>(null,!response.IsSuccessStatusCode,response);
        }

        private async Task<T?> Deserialize<T>(HttpResponseMessage response)
        {
            var responseSTR = await response.Content.ReadAsStringAsync();
            if (responseSTR == null) responseSTR = "";
            return JsonSerializer.Deserialize<T>(responseSTR,
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

    }
}
