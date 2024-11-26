
namespace ProyectoDePractica.Client.Servicios
{
    public interface IHttpService
    {
        Task<HttpResponse<T>> Get<T>(string url);
    }
}