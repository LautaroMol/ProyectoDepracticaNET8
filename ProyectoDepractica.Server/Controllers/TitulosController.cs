using Microsoft.AspNetCore.Mvc;
using ProyectoDePractica.BD.Data.Entity;
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
        public async Task<ActionResult> Put(int id, [FromBody] TituloDTO entidadDTO)
        {
            try
            {
                var enc = await _repositorio.SelectById(id);
                if (enc == null)
                {
                    return BadRequest("Datos incorrectos (id no encontrado)");
                }
                Titulo entity = mapper.Map<Titulo>(entidadDTO);
                entity.Id = id;
                var succesfull = await _repositorio.Update(id, entity);

                if (!succesfull)
                {
                    return BadRequest("No se pudo actualizar");
                }

                return Ok();
            }

            catch (Exception e) { return BadRequest(e.Message); }
        }
        [HttpPut]
        public async Task<ActionResult> AddProfesion(int id)
        {
            try
            {
                var enc = await _repositorio.SelectById(id);
                if (enc == null)
                {
                    return BadRequest("Datos incorrectos (id no encontrado)");
                }

                var succesfull = await _repositorio.Update(id, enc);

                if (!succesfull)
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
