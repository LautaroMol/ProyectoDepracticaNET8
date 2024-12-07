using Microsoft.AspNetCore.Mvc;
using ProyectoDepractica.Server.Repositorio;
using ProyectoDePractica.BD.Data.Entity;
using ProyectoDePractica.Shared.DTOs;

namespace ProyectoDepractica.Server.Controllers
{
    [ApiController]
    [Route("api/TdocTit")]
    public class TDocTituloController : ControllerBase
    {
        public ITituloRepositorio _repositorioTitulo;
        public ITDocumentoRepositorio _repositorioTdocumento;

        public TDocTituloController(ITituloRepositorio RepositorioTitulo, ITDocumentoRepositorio repositorioTDocumento) 
        {
            _repositorioTitulo = RepositorioTitulo;
            _repositorioTdocumento = repositorioTDocumento;
        }

        [HttpGet("GetTitulos")]
        public async Task<ActionResult<List<Titulo>>> GetTitulos()
        {
            return await _repositorioTitulo.Select();
        }

        [HttpGet("GetTDocs")]
        public async Task<ActionResult<List<TDocumento>>> GetTDocumentos()
        {
            return await _repositorioTdocumento.Select();
        }
        [HttpPost]
        public async Task<ActionResult<int>> Post(CreateTdoc_TituloDTO entityDTO)
        {
            try
            {
                var existTDoc = await _repositorioTdocumento.SelectByCod(entityDTO.CodigoTdoc);
                var existTit = await _repositorioTitulo.SelectByCod(entityDTO.CodigoTitulo);
                if (existTDoc != null)
                {
                    return BadRequest($"El codigo del tipo de documento {entityDTO.CodigoTdoc} no existe");
                }
                if (existTit != null) { return BadRequest($"El codigo del titulo no existe {entityDTO.CodigoTitulo}"); }
                TDocumento entTdoc = new TDocumento
                {
                    Codigo = entityDTO.CodigoTdoc,
                    Nombre = entityDTO.NombreTdoc,
                };
                int idTDoc = await _repositorioTdocumento.Insert(entTdoc);
                if (idTDoc == 0) { return BadRequest("no se pudo cargar el tipo de documento"); }
                Titulo entTitulo = new Titulo
                {
                    Codigo = entityDTO.CodigoTitulo,
                    Nombre = entityDTO.NombreTitulo,
                };
                int idTitulo = await _repositorioTitulo.Insert(entTitulo);
                if (idTitulo == 0) { return BadRequest("no se pudo cargar el titulo"); }
                return Ok(idTitulo);

            } catch (Exception ex) { throw; }
        }

    }
}
