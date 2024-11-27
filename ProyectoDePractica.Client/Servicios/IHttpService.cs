
namespace ProyectoDePractica.Client.Servicios
{
    public interface IHttpService
    {
        Task<HttpResponse<T>> Get<T>(string url);
        Task<HttpResponse<object>> Post<T>(string url,T entity);
        Task<HttpResponse<object>> Put<T>(string url, T entity);
    }
}