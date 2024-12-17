using ProyectoDePractica.BD.Data.Entity;

namespace ProyectoDepractica.Server.Repositorio
{
    public interface IPersonaRepositorio : IRepositorio<Persona>
    {
        Task<Persona> SelectByDni(string num);
        Task<Persona> SelectById(int id);
    }
}