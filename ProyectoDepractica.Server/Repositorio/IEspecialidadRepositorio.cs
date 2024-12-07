using ProyectoDePractica.BD.Data.Entity;

namespace ProyectoDepractica.Server.Repositorio
{
    public interface IEspecialidadRepositorio : IRepositorio<Especialidad>
    {
        Task<Especialidad> SelectByCod(string code);
    }
}
