using System.Threading.Tasks;
using EnveloperWeb.Application.DTOs;
using EnveloperWeb.Application.Envelopes.ConclusaoEnvelope.Contracts;
using EnveloperWeb.Domain.Contracts;
using EnveloperWeb.Domain.Envelopes.Contracts;

namespace EnveloperWeb.Application.Envelopes.ConclusaoEnvelope.Services
{
    public class ConcluirEnvelopeService : IConcluirEnvelopeService
    {
        private readonly IEnvelopeRepository _envelopeRepository;

        public ConcluirEnvelopeService(IEnvelopeRepository envelopeRepository)
        {
            _envelopeRepository = envelopeRepository;
        }

        public async Task ConcluirAsync(ConcluirEnvelopeDto dto)
        {
            var envelope = await _envelopeRepository.GetByIdAsync(dto.Id);
            if (envelope == null) return;

            envelope.DataFechamentoCaixa = dto.Data;
            envelope.HoraFechamentoCaixa = dto.Hora;
            envelope.DinheiroFinal = dto.DinheiroFinal;
            envelope.Faturamento = dto.Faturamento;
            envelope.VendasCartao = dto.VendasCartao;
            envelope.SangriaTotalCaixa = dto.Sangria;
            envelope.ReforcoTotalCaixa = dto.Reforco;
            envelope.EnvelopeDinheiro = dto.EnvelopeDinheiro;
            envelope.PassagemCaixaDinheiro = dto.Repasse;
            envelope.EnvelopeConferido = dto.Conferido;
            envelope.Observacao = dto.Observacao;

            await _envelopeRepository.UpdateAsync(envelope);
        }
    }
}
