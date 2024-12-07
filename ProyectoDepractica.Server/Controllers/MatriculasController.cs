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
    }
}
