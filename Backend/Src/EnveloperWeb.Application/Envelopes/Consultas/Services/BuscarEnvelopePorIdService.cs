using System.Threading.Tasks;
using EnveloperWeb.Application.DTOs;
using EnveloperWeb.Application.Envelopes.Consultas.Contracts;
using EnveloperWeb.Domain.Envelopes.Contracts;

namespace EnveloperWeb.Application.Envelopes.Consultas.Services
{
    public class BuscarEnvelopePorIdService : IBuscarEnvelopePorIdService
    {
        private readonly IEnvelopeRepository _repository;

        public BuscarEnvelopePorIdService(IEnvelopeRepository repository)
        {
            _repository = repository;
        }

        public async Task<EnvelopeDetalhadoDto> BuscarAsync(int id)
        {
            return await _repository.BuscarEnvelopeDetalhadoAsync(id);
        }
    }
}
