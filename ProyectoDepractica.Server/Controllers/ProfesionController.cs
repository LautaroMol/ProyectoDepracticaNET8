using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProyectoDePractica.BD.Data.Entity;
using ProyectoDepractica.Server.Repositorio;
using ProyectoDePractica.Shared.DTOs;

namespace ProyectoDepractica.Server.Controllers
{
    [ApiController]
    [Route("api/Profesiones")]
    public class ProfesionesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProfesionRepositorio _context;

        public ProfesionesController(IMapper mapper, IProfesionRepositorio context)
        {
            _mapper = mapper;
            _context = context;

        }

        [HttpGet]
        public async Task<ActionResult<List<Profesion>>> Get()
        {
            return await _context.Select();
        }

        [HttpGet("/api/Profesion/Id/{id:int}")]
        public async Task<ActionResult<Profesion>> GetById(int id)
        {
            return await _context.SelectById(id);
        }


        [HttpPost]
        public async Task<ActionResult<int>> Post(ProfesionDTO entityDTO)
        {
            try
            {
                Profesion entity = _mapper.Map<Profesion>(entityDTO);

                return await _context.Insert(entity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] ProfesionDTO entityDTO)
        {
            try
            {
                var enc = await _context.SelectById(id);
                if (enc == null)
                {
                    return BadRequest($"Datos incorrectos {id} no encontrado");
                }
                Profesion entity = _mapper.Map<Profesion>(entityDTO);
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
            if (!enc) return NotFound($"No pudo encontrarse la Profesion de id {id}");

            if (await _context.Delete(id)) return Ok();
            return BadRequest("No pudo borrarse");

        }
    }
}
