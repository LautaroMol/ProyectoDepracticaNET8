using Microsoft.EntityFrameworkCore;
using ProyectoDePractica.BD.Data;
using ProyectoDePractica.BD.Data.Entity;

namespace ProyectoDepractica.Server.Repositorio
{
    public class TDocumentoRepositorio : Repositorio<TDocumento>, ITDocumentoRepositorio
    {
        private readonly Context _context;

        public TDocumentoRepositorio(Context context) : base(context) 
        {
            _context = context;
        }

        public async Task<TDocumento> SelectByCod(string codigo)
        {
            var enc = await _context.TDocumentos
                .FirstOrDefaultAsync(x => x.Codigo == codigo);
            return enc;
        }
    }
}
