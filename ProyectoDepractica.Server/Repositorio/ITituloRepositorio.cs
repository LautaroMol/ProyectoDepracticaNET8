using ProyectoDePractica.BD.Data.Entity;

namespace ProyectoDepractica.Server.Repositorio
{
    public interface ITituloRepositorio : IRepositorio<Titulo>
    {
        Task<Titulo> SelectByCod(string codigo);
    }
}
