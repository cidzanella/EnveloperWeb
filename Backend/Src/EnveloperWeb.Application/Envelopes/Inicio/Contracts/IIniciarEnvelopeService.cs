using System.Threading.Tasks;
using EnveloperWeb.Application.Envelopes.Inicio.DTOs;
using EnveloperWeb.Application.Wrappers;

namespace EnveloperWeb.Application.Envelopes.Inicio.Contracts
{
    public interface IIniciarEnvelopeService
    {
        Task<OperationResult<IniciarEnvelopeResponseDto>> IniciarAsync(IniciarEnvelopeRequestDto dto);
    }
}
