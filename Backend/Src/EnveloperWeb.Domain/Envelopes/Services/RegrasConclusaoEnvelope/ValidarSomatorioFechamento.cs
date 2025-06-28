using EnveloperWeb.Domain.Envelopes.Entities;
using EnveloperWeb.Domain.Shared.Validation;

namespace EnveloperWeb.Domain.Envelopes.Services.RegrasConclusaoEnvelope
{
    public class ValidarSomatorioFechamento : IConclusaoEnvelopeValidationRule
    {
        public void Validar(Envelope e, ValidationResult r)
        {
            var esperado = e.DinheiroInicial + e.Faturamento - e.VendasCartao + e.ReforcoTotalCaixa - e.SangriaTotalCaixa;
            var diferenca = Math.Round(e.DinheiroFinal - esperado, 2);

            if (diferenca != 0)
                r.AddError($"Diferença no fechamento: valor final ({e.DinheiroFinal:F2}) difere do esperado ({esperado:F2}).");
        }
    }
}