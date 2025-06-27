using System.Threading.Tasks;
using EnveloperWeb.Application.Envelopes.InicioEnvelope.Dtos;
using EnveloperWeb.Application.Wrappers;

namespace EnveloperWeb.Application.Envelopes.InicioEnvelope.Contracts
{
    public interface IIniciarEnvelopeService
    {
        Task<OperationResult<int>> IniciarAsync(IniciarEnvelopeRequestDto dto);
    }
}
