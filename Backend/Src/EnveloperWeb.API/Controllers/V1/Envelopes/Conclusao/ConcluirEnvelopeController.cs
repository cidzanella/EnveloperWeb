using EnveloperWeb.Application.Envelopes.Conclusao.Contracts;
using EnveloperWeb.Application.Envelopes.Conclusao.DTOs;
using EnveloperWeb.Application.Wrappers;
using Microsoft.AspNetCore.Mvc;

namespace EnveloperWeb.API.Controllers.V1.Envelopes.Conclusao
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/envelopes/conclusao")]
    public class ConcluirEnvelopeController : ControllerBase
    {
        private readonly IConcluirEnvelopeService _concluirEnvelopeService;

        public ConcluirEnvelopeController(IConcluirEnvelopeService concluirEnvelopeService)
        {
            _concluirEnvelopeService = concluirEnvelopeService;
        }

        /// <summary>
        /// Conclui um envelope registrando valores de fechamento e informações finais.
        /// Retorna os dados consolidados e o recibo formatado.
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse<ConcluirEnvelopeResponseDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<string>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<string>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ConcluirEnvelope([FromBody] ConcluirEnvelopeRequestDto request)
        {
            var resultado = await _concluirEnvelopeService.ConcluirAsync(request);

            if (!resultado.IsSuccess)
                return BadRequest(new ApiResponse<string>(string.Join(" | ", resultado.Errors)));

            return Ok(new ApiResponse<ConcluirEnvelopeResponseDto>(resultado.Data, "Envelope concluído com sucesso."));
        }
    }
}
