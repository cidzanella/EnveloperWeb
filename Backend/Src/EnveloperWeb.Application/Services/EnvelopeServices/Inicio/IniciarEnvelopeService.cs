using System.Threading.Tasks;
using EnveloperWeb.Application.DTOs;
using EnveloperWeb.Domain.Contracts;
using EnveloperWeb.Domain.Contracts.Repositories;
using EnveloperWeb.Domain.Entities;

namespace EnveloperWeb.Application.Services.EnvelopeServices.Inicio
{
    public class IniciarEnvelopeService : IIniciarEnvelopeService
    {
        private readonly IEnvelopeRepository _envelopeRepository;

        public IniciarEnvelopeService(IEnvelopeRepository envelopeRepository)
        {
            _envelopeRepository = envelopeRepository;
        }

        public async Task<int> IniciarAsync(IniciarEnvelopeDto dto)
        {
            var envelope = new Envelope
            {
                DataAberturaCaixa = dto.Data,
                HoraAberturaCaixa = dto.Hora,
                DinheiroInicial = dto.DinheiroInicial,
                Observacao = dto.Observacao,
                ClimaId = dto.ClimaId,
                TurnoId = dto.TurnoId,
                PDV = dto.PDV
            };

            await _envelopeRepository.AddAsync(envelope);
            return envelope.Id;
        }
    }
}
