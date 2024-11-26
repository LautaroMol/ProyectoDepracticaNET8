using Microsoft.AspNetCore.Mvc;
using ProyectoDePractica.BD.Data.Entity;
using ProyectoDePractica.BD.Data;
using Microsoft.EntityFrameworkCore;
using ProyectoDePractica.Shared.DTOs;
using AutoMapper;
using ProyectoDepractica.Server.Repositorio;

namespace ProyectoDepractica.Server.Controllers
{
    [ApiController]
    [Route("api/Titulos")]
    public class TitulosControllers : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ITituloRepositorio _repositorio;
        public TitulosControllers(ITituloRepositorio repositorio,IMapper mapper)
        {
            _repositorio = repositorio;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Titulo>>> Get()
        {
            return await _repositorio.Select(); 
        }
        [HttpGet("{id:int}")] // api/Titulos/id
        public async Task<ActionResult<Titulo>> Get(int id)
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
        [HttpPost]
        public async Task<ActionResult<int>> Post(TituloDTO entidadDTO)
        {
            try
            {
                Titulo ent = mapper.Map<Titulo>(entidadDTO);

                return await _repositorio.Insert(ent);
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] Titulo entidad)
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

        [HttpDelete("{id:int}")] //api / Titulos/id
        public async Task<ActionResult> Delete(int id)
        {
            var enc = await _repositorio.Existe(id);
            if (!enc) return NotFound($"El numero de documento {id} no existe.");

            if (await _repositorio.Delete(id)) return Ok();
            return BadRequest();
        }
    }
}
