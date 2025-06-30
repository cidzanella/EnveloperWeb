using AutoMapper;
using EnveloperWeb.Application.Envelopes.Conferencia.Contracts;
using EnveloperWeb.Application.Envelopes.Conferencia.DTOs;
using EnveloperWeb.Application.Envelopes.Consultas.DTOs;
using EnveloperWeb.Application.Wrappers;
using EnveloperWeb.Domain.Envelopes.Contracts;
using EnveloperWeb.Domain.Shared.Contracts;
using System.Threading.Tasks;

namespace EnveloperWeb.Application.Envelopes.Conferencia.Services
{
    public class ConferirEnvelopeService : IConferirEnvelopeService
    {
        private readonly IEnvelopeRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ConferirEnvelopeService(IEnvelopeRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<OperationResult<ConferirEnvelopeResponseDto>> ConferirAsync(ConferirEnvelopeRequestDto dto)
        {
            var envelope = await _repository.ObterPorIdAsync(dto.EnvelopeId);
            if (envelope == null)
                return OperationResult<ConferirEnvelopeResponseDto>.Failure(new[] { "Envelope não encontrado." });

            var dinheiroSistema = (decimal)envelope.EnvelopeDinheiro;
            var diferenca = dto.DinheiroEncontrado - dinheiroSistema;

            envelope.EnvelopeConferido = true;
            envelope.EnvelopeDinheiroDiferenca = (double)diferenca;
            envelope.Observacao = $"{envelope.Observacao?.Trim()} {dto.Observacao}".Trim();

            await _repository.AtualizarAsync(envelope);
            await _unitOfWork.CommitAsync();

            var response = new ConferirEnvelopeResponseDto
            {
                EnvelopeId = envelope.Id,
                DinheiroSistema = dinheiroSistema,
                DinheiroEncontrado = dto.DinheiroEncontrado,
                Diferenca = diferenca,
                EnvelopeConferido = true,
                ObservacaoFinal = envelope.Observacao
            };

            return OperationResult<ConferirEnvelopeResponseDto>.Success(response);
        }

        public async Task<OperationResult<List<EnvelopeResumoDto>>> ListarNaoConferidosAsync()
        {
            var envelopes = await _repository.ListarEnvelopesNaoConferidosAsync();
            var dtos = _mapper.Map<List<EnvelopeResumoDto>>(envelopes);
            return OperationResult<List<EnvelopeResumoDto>>.Success(dtos);
        }

    }
}
