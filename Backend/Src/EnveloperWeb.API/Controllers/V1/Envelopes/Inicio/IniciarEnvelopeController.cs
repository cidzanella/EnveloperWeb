using EnveloperWeb.Application.Envelopes.Inicio.Contracts;
using EnveloperWeb.Application.Envelopes.Inicio.DTOs;
using EnveloperWeb.Application.Wrappers;
using Microsoft.AspNetCore.Mvc;

namespace EnveloperWeb.API.Controllers.V1.Envelopes.Inicio
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/envelopes/inicio")]
    public class IniciarEnvelopeController : ControllerBase
    {
        private readonly IIniciarEnvelopeService _iniciarEnvelopeService;

        public IniciarEnvelopeController(IIniciarEnvelopeService iniciarEnvelopeService)
        {
            _iniciarEnvelopeService = iniciarEnvelopeService;
        }

        /// <summary>
        /// Inicia um novo envelope registrando a abertura do caixa.
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse<IniciarEnvelopeResponseDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<string>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<string>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> IniciarEnvelope([FromBody] IniciarEnvelopeRequestDto request)
        {
            var resultado = await _iniciarEnvelopeService.IniciarAsync(request);

            if (!resultado.IsSuccess)
                return BadRequest(new ApiResponse<string>(string.Join(" | ", resultado.Errors)));

            return Ok(new ApiResponse<IniciarEnvelopeResponseDto>(resultado.Data, "Envelope iniciado com sucesso."));
        }
    }
}
