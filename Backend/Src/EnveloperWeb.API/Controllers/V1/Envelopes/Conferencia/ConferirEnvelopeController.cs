using EnveloperWeb.Application.Envelopes.Conferencia.Contracts;
using EnveloperWeb.Application.Envelopes.Conferencia.DTOs;
using EnveloperWeb.Application.Envelopes.Consultas.DTOs;
using EnveloperWeb.Application.Wrappers;
using Microsoft.AspNetCore.Mvc;

namespace EnveloperWeb.API.Controllers.V1.Envelopes.Conferencia
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/envelopes/conferencia")]
    public class ConferirEnvelopeController : ControllerBase
    {
        private readonly IConferirEnvelopeService _conferirEnvelopeService;

        public ConferirEnvelopeController(IConferirEnvelopeService conferirEnvelopeService)
        {
            _conferirEnvelopeService = conferirEnvelopeService;
        }

        /// Confere um envelope, informando o valor encontrado fisicamente e observações finais.
        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse<ConferirEnvelopeResponseDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<string>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<string>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ConferirEnvelope([FromBody] ConferirEnvelopeRequestDto request)
        {
            var resultado = await _conferirEnvelopeService.ConferirAsync(request);

            if (!resultado.IsSuccess)
                return BadRequest(new ApiResponse<string>(string.Join(" | ", resultado.Errors)));

            return Ok(new ApiResponse<ConferirEnvelopeResponseDto>(resultado.Data, "Envelope conferido com sucesso."));
        }

        /// Lista envelopes ainda não conferidos (úteis para relatórios e acompanhamento).
        [HttpGet("nao-conferidos")]
        [ProducesResponseType(typeof(ApiResponse<List<EnvelopeResumoDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ListarNaoConferidos()
        {
            var resultado = await _conferirEnvelopeService.ListarNaoConferidosAsync();
            return Ok(new ApiResponse<List<EnvelopeResumoDto>>(resultado.Data));
        }

    }
}
