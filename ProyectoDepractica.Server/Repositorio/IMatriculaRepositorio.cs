using ProyectoDePractica.BD.Data.Entity;

namespace ProyectoDepractica.Server.Repositorio
{
    public interface IMatriculaRepositorio : IRepositorio<Matricula>
    {
        Task<Matricula> SelectByNum(string num);
    }
}