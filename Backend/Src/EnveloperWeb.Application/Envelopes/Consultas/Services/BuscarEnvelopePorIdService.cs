using System.Threading.Tasks;
using AutoMapper;
using EnveloperWeb.Application.Envelopes.Consultas.Contracts;
using EnveloperWeb.Application.Envelopes.Consultas.DTOs;
using EnveloperWeb.Application.Wrappers;
using EnveloperWeb.Domain.Envelopes.Contracts;

namespace EnveloperWeb.Application.Envelopes.Consultas.Services
{
    public class BuscarEnvelopePorIdService : IBuscarEnvelopePorIdService
    {
        private readonly IEnvelopeRepository _repository;
        private readonly IMapper _mapper;

        public BuscarEnvelopePorIdService(IEnvelopeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<OperationResult<EnvelopeDetalhadoDto>> BuscarAsync(int id)
        {
            var envelope = await _repository.ObterPorIdComDadosCompletosAsync(id);

            if (envelope == null)
                return OperationResult<EnvelopeDetalhadoDto>.Failure(new[] { "Envelope não encontrado." });

            var dto = _mapper.Map<EnvelopeDetalhadoDto>(envelope);
            return OperationResult<EnvelopeDetalhadoDto>.Success(dto);
        }
    }
}
