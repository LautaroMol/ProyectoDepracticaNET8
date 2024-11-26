using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProyectoDePractica.BD.Data;
using ProyectoDePractica.BD.Data.Entity;

namespace ProyectoDepractica.Server.Repositorio
{
    public class Repositorio<E> : IRepositorio<E> where E : class, IEntityBase
    {
        private readonly Context _context;
        public Repositorio(Context context)
        {
            _context = context;
        }

        public async Task<List<E>> Select()
        {
            return await _context.Set<E>().ToListAsync();
        }

        public async Task<E> SelectById(int id)
        {
            var exist = await _context.Set<E>().AsNoTracking().FirstOrDefaultAsync(
                x => x.Id == id);
            return exist;
        }

        public async Task<bool> Existe(int id)
        {
            var exist = await _context.Set<E>()
                .AnyAsync(x => x.Id == id);
            return exist;
        }

        public async Task<int> Insert(E entidad)
        {
            try
            {
                await _context.Set<E>().AddAsync(entidad);
                await _context.SaveChangesAsync();
                return entidad.Id;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> Update(int id, E entidad)
        {
            if (id != entidad.Id)
            {
                return false;
            }
            var enc = await SelectById(id);

            if (enc == null)
            {
                return false;
            }

            try
            {
                _context.Set<E>().Update(entidad);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e) { throw e; }
        }

        public async Task<bool> Delete(int id)
        {
            var exist = await SelectById(id);
            if (exist == null)
            {
                return false;
            }
            _context.Set<E>().Remove(exist);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
