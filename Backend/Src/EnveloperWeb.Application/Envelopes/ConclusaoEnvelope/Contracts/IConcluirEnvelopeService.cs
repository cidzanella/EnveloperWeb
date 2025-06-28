using System.Threading.Tasks;
using EnveloperWeb.Application.DTOs;

namespace EnveloperWeb.Application.Envelopes.ConclusaoEnvelope.Contracts
{
    public interface IConcluirEnvelopeService
    {
        Task ConcluirAsync(ConcluirEnvelopeDto dto);
    }
}
