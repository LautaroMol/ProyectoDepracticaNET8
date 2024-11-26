using ProyectoDePractica.BD.Data;
using ProyectoDePractica.BD.Data.Entity;

namespace ProyectoDepractica.Server.Repositorio
{
    public class EspecialidadRepositorio : Repositorio<Especialidad>, IEspecialidadRepositorio
    {
        private readonly Context _context;

        public EspecialidadRepositorio(Context context) : base(context)
        {
            _context = context;
        }
    }
}
