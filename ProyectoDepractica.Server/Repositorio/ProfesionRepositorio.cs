using ProyectoDePractica.BD.Data;
using ProyectoDePractica.BD.Data.Entity;

namespace ProyectoDepractica.Server.Repositorio
{
    public class ProfesionRepositorio : Repositorio<Profesion>, IProfesionRepositorio
    {
        private readonly Context _context;
        public ProfesionRepositorio(Context context) : base(context)
        {
            _context = context;
        }

    }

}
