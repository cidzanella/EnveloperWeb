using EnveloperWeb.Application.Envelopes.Conclusao.DTOs;
using EnveloperWeb.Application.Wrappers;
using System.Threading.Tasks;

namespace EnveloperWeb.Application.Envelopes.Conclusao.Contracts
{
    public interface IConcluirEnvelopeService
    {
        Task<OperationResult<ConcluirEnvelopeResponseDto>> ConcluirAsync(ConcluirEnvelopeRequestDto dto);
    }
}
