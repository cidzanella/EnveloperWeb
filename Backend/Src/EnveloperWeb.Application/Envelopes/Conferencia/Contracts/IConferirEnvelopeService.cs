using EnveloperWeb.Application.Envelopes.Conferencia.DTOs;
using EnveloperWeb.Application.Envelopes.Consultas.DTOs;
using EnveloperWeb.Application.Wrappers;

namespace EnveloperWeb.Application.Envelopes.Conferencia.Contracts
{
    public interface IConferirEnvelopeService
    {
        Task<OperationResult<ConferirEnvelopeResponseDto>> ConferirAsync(ConferirEnvelopeRequestDto dto);
        Task<OperationResult<List<EnvelopeResumoDto>>> ListarNaoConferidosAsync();

    }
}
