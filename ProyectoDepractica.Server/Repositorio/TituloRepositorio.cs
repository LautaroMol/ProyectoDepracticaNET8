using Microsoft.EntityFrameworkCore;
using ProyectoDePractica.BD.Data;
using ProyectoDePractica.BD.Data.Entity;

namespace ProyectoDepractica.Server.Repositorio
{
    public class TituloRepositorio :Repositorio<Titulo>, ITituloRepositorio
    {
        private readonly Context _context;
        public TituloRepositorio(Context context) : base(context)
        {
            _context = context;
        }

        public async Task<Titulo> SelectByCod(string codigo)
        {
            var enc = await _context.Titulos.AsNoTracking()
                .FirstOrDefaultAsync(x => x.Codigo == codigo);
            return enc;
        }
    }
}
