using Microsoft.EntityFrameworkCore;
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
        public async Task<Especialidad> SelectByCod(string code)
        {
            var enc = await _context.Especialidades.AsNoTracking()
                .FirstOrDefaultAsync(x => x.Codigo == code);
            return enc;
        }
    }
}
