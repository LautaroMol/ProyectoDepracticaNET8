using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using ProyectoDePractica.BD.Data;
using ProyectoDePractica.BD.Data.Entity;

namespace ProyectoDepractica.Server.Repositorio
{
    public class MatriculaRepositorio : Repositorio<Matricula>, IMatriculaRepositorio
    {
        private readonly Context _context;

        public MatriculaRepositorio(Context context) : base(context)
        {
            _context = context;
        }

        public async Task<Matricula> SelectByNum(string num)
        {
            var found = await _context.Matriculas.AsNoTracking()
                .FirstOrDefaultAsync(x => x.Numero == num);
            return found;
        }
    }
}
