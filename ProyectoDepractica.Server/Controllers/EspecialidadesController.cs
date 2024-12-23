﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProyectoDepractica.Server.Repositorio;
using ProyectoDePractica.BD.Data;
using ProyectoDePractica.BD.Data.Entity;
using ProyectoDePractica.Shared.DTOs;

namespace ProyectoDepractica.Server.Controllers
{
    [ApiController]
    [Route("api/Especialidades")]
    public class EspecialidadesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IEspecialidadRepositorio _context;

        public EspecialidadesController(IMapper mapper, IEspecialidadRepositorio context )
        {
            _mapper = mapper;
            _context = context;

        }
        [HttpGet]
        public async Task<ActionResult<List<Especialidad>>> Get()
        {
            return await _context.Select();
        }

        [HttpGet("/especialidad/{id:int}")]
        public async Task<ActionResult<Especialidad>> GetById(int id)
        {
            return await _context.SelectById(id);
        }

        [HttpGet("/codigo/{cod:int}")]
        public async Task<ActionResult<Especialidad>> GetByCod(string cod)
        {
            return await _context.SelectByCod(cod);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(EspecialidadDTO entityDTO)
        {
            try
            {
                Especialidad entity = _mapper.Map<Especialidad>(entityDTO);

                return await _context.Insert(entity);
            }catch (Exception ex) { 
                return BadRequest(ex.InnerException.Message); 
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] EspecialidadDTO entityDTO)
        {
            try
            {
                var enc = await _context.SelectById(id);
                if (enc == null)
                {
                    return BadRequest($"Datos incorrectos {id} no encontrado");
                }
                Especialidad entity = _mapper.Map<Especialidad>(entityDTO);
                entity.Id = id;
                var succes = await _context.Update(id, entity);

                if (!succes)
                {
                    return BadRequest("No se pudo actualizar");
                }

                return Ok();
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var enc = await _context.Existe(id);
            if (!enc) return NotFound($"No pudo encontrarse la especialidad de id {id}");

            if (await _context.Delete(id)) return Ok();
            return BadRequest("No pudo borrarse");

        }

    }
}
