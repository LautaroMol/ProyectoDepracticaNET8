using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProyectoDepractica.Server.Repositorio;
using ProyectoDePractica.BD.Data.Entity;
using ProyectoDePractica.Shared.DTOs;

namespace ProyectoDepractica.Server.Controllers
{
    [ApiController]
    [Route("api/Personas")]
    public class PersonasController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPersonaRepositorio _context;

        public PersonasController(IMapper mapper, IPersonaRepositorio context)
        {
            _mapper = mapper;
            _context = context;

        }

        [HttpGet]
        public async Task<ActionResult<List<Persona>>> Get()
        {
            return await _context.Select();
        }

        [HttpGet("/api/Persona/Id/{id:int}")]
        public async Task<ActionResult<Persona>> GetById(int id)
        {
            return await _context.SelectById(id);
        }

        [HttpGet("/api/Persona/dni/{dni:int}")]
        public async Task<ActionResult<Persona>> GetByCod(string dni)
        {
            return await _context.SelectByDni(dni);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(PersonaDTO entityDTO)
        {
            try
            {
                Persona entity = _mapper.Map<Persona>(entityDTO);

                return await _context.Insert(entity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] PersonaDTO entityDTO)
        {
            try
            {
                var enc = await _context.SelectById(id);
                if (enc == null)
                {
                    return BadRequest($"Datos incorrectos {id} no encontrado");
                }
                Persona entity = _mapper.Map<Persona>(entityDTO);
                entity.Id = id;
                var succes = await _context.Update(id, entity);

                if (!succes)
                {
                    return BadRequest("No se pudo actualizar");
                }

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var enc = await _context.Existe(id);
            if (!enc) return NotFound($"No pudo encontrarse la Persona de id {id}");

            if (await _context.Delete(id)) return Ok();
            return BadRequest("No pudo borrarse");

        }
    }
}
