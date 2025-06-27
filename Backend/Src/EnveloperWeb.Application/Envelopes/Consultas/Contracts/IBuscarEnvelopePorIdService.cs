using System.Threading.Tasks;
using EnveloperWeb.Application.DTOs;

namespace EnveloperWeb.Application.Envelopes.Consultas.Contracts
{
    public interface IBuscarEnvelopePorIdService
    {
        Task<EnvelopeDetalhadoDto> BuscarAsync(int id);
    }
}
