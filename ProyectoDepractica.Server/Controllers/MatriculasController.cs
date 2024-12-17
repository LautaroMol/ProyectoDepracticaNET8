using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProyectoDepractica.Server.Repositorio;
using ProyectoDePractica.BD.Data.Entity;
using ProyectoDePractica.Shared.DTOs;

namespace ProyectoDepractica.Server.Controllers
{
    [ApiController]
    [Route("api/Matriculas")]
    public class MatriculasController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMatriculaRepositorio _context;

        public MatriculasController(IMapper mapper, IMatriculaRepositorio context)
        {
            _mapper = mapper;
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Matricula>>> Get()
        {
            return await _context.Select();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Matricula>> GetById(int id)
        {
            return await _context.SelectById(id);
        }

        [HttpGet("/numero/{numero:int}")]
        public async Task<ActionResult<Matricula>> GetByNum(string num)
        {
            return await _context.SelectByNum(num);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(MatriculaDTO entityDTO)
        {
            try
            {
                Matricula entity = _mapper.Map<Matricula>(entityDTO);

                return await _context.Insert(entity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int idMatricula,[FromBody] MatriculaDTO matriculaDTO)
        {
            try
            {
                var enc = await _context.SelectById(idMatricula);
                if(enc == null)
                {
                    return BadRequest($"no se encontro la matricula de id {idMatricula}");
                }
                Matricula entity = _mapper.Map<Matricula>(matriculaDTO);
                entity.Id = idMatricula;
                var success = await _context.Update(idMatricula,entity);

                if (!success) return BadRequest("No se pudo actualizar");
                return Ok(success);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var enc = _context.SelectById(id);
            if (enc == null) return NotFound($"No pudo encontrarse la especialidad de id {id}");

            if (await _context.Delete(id)) return Ok();
            return BadRequest("No pudo borrarse");
        }
    }
}
