using System.Threading.Tasks;
using EnveloperWeb.Application.Envelopes.Consultas.DTOs;
using EnveloperWeb.Application.Wrappers;

namespace EnveloperWeb.Application.Envelopes.Consultas.Contracts
{
    public interface IBuscarEnvelopePorIdService
    {
        Task<OperationResult<EnvelopeDetalhadoDto>> BuscarAsync(int id);
    }
}
