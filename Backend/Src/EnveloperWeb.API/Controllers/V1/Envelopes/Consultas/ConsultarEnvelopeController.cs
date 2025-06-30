using EnveloperWeb.Application.Envelopes.Consultas.Contracts;
using EnveloperWeb.Application.Envelopes.Consultas.DTOs;
using EnveloperWeb.Application.Wrappers;
using Microsoft.AspNetCore.Mvc;

namespace EnveloperWeb.API.Controllers.V1.Envelopes.Consultas
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/envelopes/consultas")]
    public class ConsultarEnvelopeController : ControllerBase
    {
        private readonly IListarEnvelopesService _listarService;
        private readonly IBuscarEnvelopePorIdService _buscarService;

        public ConsultarEnvelopeController(
            IListarEnvelopesService listarService,
            IBuscarEnvelopePorIdService buscarService)
        {
            _listarService = listarService;
            _buscarService = buscarService;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiResponse<EnvelopeDetalhadoDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<string>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var resultado = await _buscarService.BuscarAsync(id);
            if (!resultado.IsSuccess)
                return NotFound(new ApiResponse<string>(string.Join(" | ", resultado.Errors)));

            return Ok(new ApiResponse<EnvelopeDetalhadoDto>(resultado.Data));
        }

        [HttpGet]
        [ProducesResponseType(typeof(ApiResponse<List<EnvelopeResumoDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Listar([FromQuery] EnvelopeFiltroConsultaDto filtro)
        {
            var resultado = await _listarService.ListarAsync(filtro);
            return Ok(new ApiResponse<List<EnvelopeResumoDto>>(resultado.Data));
        }
    }
}
