using Microsoft.EntityFrameworkCore;
using ProyectoDePractica.BD.Data;
using ProyectoDePractica.BD.Data.Entity;

namespace ProyectoDepractica.Server.Repositorio
{
    public class PersonaRepositorio : Repositorio<Persona>, IPersonaRepositorio
    {
        private readonly Context _context;

        public PersonaRepositorio(Context context) : base(context)
        {
            _context = context;
        }

        public async Task<Persona> SelectByDni(string num)
        {
            var enc = await _context.Personas.AsNoTracking().FirstOrDefaultAsync(
                x => x.NumDoc == num);
            return enc;
        }


        public async Task<Persona> SelectById(int id)
        {
            var enc = await _context.Personas.AsNoTracking().FirstOrDefaultAsync(
                x => x.Id == id);
            return enc;
        }
    }
}
