using EnveloperWeb.Application.Faturamento.Contracts;
using EnveloperWeb.Domain.Envelopes.Contracts;

namespace EnveloperWeb.Application.Faturamento.Services
{
    public class ProjecaoFaturamentoMensalService : IProjecaoFaturamentoMensalService
    {
        private readonly IEnvelopeRepository _envelopeRepository;
        private const double FatorAtenuacao = 0.9;

        public ProjecaoFaturamentoMensalService(IEnvelopeRepository envelopeRepository)
        {
            _envelopeRepository = envelopeRepository;
        }

        public async Task<double> CalcularAsync(int ano, int mes)
        {
            var faturamentos = await _envelopeRepository.ObterFaturamentoDiarioDoMesAsync(ano, mes);

            if (faturamentos.Count == 0)
                return 0;

            var dias = faturamentos.Select(f => f.Data.Day).Distinct().Count();
            var soma = faturamentos.Sum(f => f.Faturamento);

            switch (dias)
            {
                case 7:
                    return soma + 3 * soma * FatorAtenuacao; // Semana 1
                case 10:
                    return soma + 2 * soma * FatorAtenuacao; // 10 dias
                case 14:
                    var ordenados = faturamentos.OrderBy(f => f.Data).ToList();
                    var semana1 = ordenados.Take(7).Sum(f => f.Faturamento);
                    var semana2 = ordenados.Skip(7).Take(7).Sum(f => f.Faturamento);
                    return semana1 + semana2 + 2 * (semana2 * FatorAtenuacao);
                case 15:
                    return soma + soma * FatorAtenuacao;
                default:
                    var media = soma / dias;
                    return media * 30;
            }
        }
    }
}
