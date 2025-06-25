using EnveloperWeb.Application.Services.FaturamentoServices;
using EnveloperWeb.Domain.Contracts.Repositories;
using EnveloperWeb.Domain.Entities;

namespace EnveloperWeb.Application.Services.FaturamentoServices
{
    public class ProjecaoFaturamentoMensalService : IProjecaoFaturamentoMensalService
    {
        private readonly IEnvelopeRepository _envelopeRepository;

        public ProjecaoFaturamentoMensalService(IEnvelopeRepository envelopeRepository)
        {
            _envelopeRepository = envelopeRepository;
        }

        public double CalcularProjecao(int ano, int mes)
        {
            var envelopes = _envelopeRepository.ObterPorAnoEMes(ano, mes);
            var diasUteisComFechamento = envelopes
                .Where(e => e.DataFechamentoCaixa.HasValue)
                .GroupBy(e => e.DataFechamentoCaixa.Value.Date)
                .Select(g => new { Dia = g.Key.Day, Faturamento = g.Sum(x => x.Faturamento) })
                .OrderBy(x => x.Dia)
                .ToList();

            if (diasUteisComFechamento.Count == 0)
                return 0;

            // Estratégias possíveis (em ordem de prioridade)
            if (diasUteisComFechamento.Count >= 15)
                return CalcularProjecaoMultiplicadora(diasUteisComFechamento.Take(15), 2);

            if (diasUteisComFechamento.Count >= 14)
                return CalcularProjecaoDivisaoMultiplicacao(diasUteisComFechamento.Take(14), 2, 4);

            if (diasUteisComFechamento.Count >= 10)
                return CalcularProjecaoMultiplicadora(diasUteisComFechamento.Take(10), 3);

            if (diasUteisComFechamento.Count >= 7)
                return CalcularProjecaoMultiplicadora(diasUteisComFechamento.Take(7), 4);

            // fallback: média diária x 30
            double mediaDiaria = diasUteisComFechamento.Average(x => x.Faturamento);
            return Math.Round(mediaDiaria * 30, 2);
        }

        private double CalcularProjecaoMultiplicadora(IEnumerable<dynamic> dias, int multiplicador)
        {
            double total = dias.Sum(x => (double)x.Faturamento);
            return Math.Round(total * multiplicador, 2);
        }

        private double CalcularProjecaoDivisaoMultiplicacao(IEnumerable<dynamic> dias, int divisor, int multiplicador)
        {
            double total = dias.Sum(x => (double)x.Faturamento);
            return Math.Round((total / divisor) * multiplicador, 2);
        }
    }
}
