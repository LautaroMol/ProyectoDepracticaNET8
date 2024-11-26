using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ProyectoDepractica.Server.Repositorio;
using ProyectoDePractica.BD.Data;
using ProyectoDePractica.BD.Data.Entity;

namespace ProyectoDepractica.Server.Controllers
{
    [ApiController]
    [Route("api/TDocumentos")]
    public class TDocumentosControllers : ControllerBase
    {
        private readonly ITDocumentoRepositorio _repositorio;

        public TDocumentosControllers(ITDocumentoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<TDocumento>>> Get()
        {
            return await _repositorio.Select();
        }
        [HttpGet("SelectById/{id:int}")] // api/TDocumentos/id
        public async Task<ActionResult<TDocumento>> Get(int id)
        {
            var enc = await _repositorio.SelectById(id);
            if (enc == null)
            {
                return NotFound();
            }
            return enc;
        }
        [HttpGet("Existe/{id:int}")]
        public async Task<ActionResult<bool>> Existe(int id)
        {
            var exist = await _repositorio.Existe(id);
            return exist;
        }
        [HttpGet("GetByCod/{cod}")]
        public async Task<ActionResult<TDocumento>> GetByCod(string cod)
        {
            return await _repositorio.SelectByCod(cod);
        }
        [HttpPost]
        public async Task<ActionResult<int>> Post(TDocumento entidad)
        {
            try
            {
                return await _repositorio.Insert(entidad); ;
            }catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id,[FromBody] TDocumento entidad)
        {
            try
            {
                if (id != entidad.Id)
                {
                    return BadRequest("Datos incorrectos (id no concordante)");
                }
                var enc = await _repositorio.Update(id, entidad);

                if (!enc)
                {
                    return BadRequest("No se pudo actualizar");
                }

                return Ok();
            }
 
            catch (Exception e) { return BadRequest(e.Message); }
        }

        [HttpDelete("{id:int}")] //api / TDocumentos/id
        public async Task<ActionResult> Delete(int id)
        {
            var resp = await _repositorio.Delete(id);
            if (!resp)
            {
                return BadRequest("No se ha podido borrar el tipo de documento");
            }
            else
            {
                return Ok();
            }
        }
    }
}
