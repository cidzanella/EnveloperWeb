using EnveloperWeb.Domain.Envelopes.Entities;
using EnveloperWeb.Domain.Shared.Validation;

namespace EnveloperWeb.Domain.Envelopes.Services.RegrasConclusaoEnvelope
{ 
    public class ValidarCamposNumericos : IConclusaoEnvelopeValidationRule
    {
        public void Validar(Envelope e, ValidationResult r)
        {
            if (e.DinheiroFinal < 0) r.AddError("Dinheiro final não pode ser negativo.");
            if (e.Faturamento < 0) r.AddError("Faturamento total não pode ser negativo.");
            if (e.VendasCartao < 0) r.AddError("Vendas no cartão não podem ser negativas.");
            if (e.SangriaTotalCaixa < 0) r.AddError("Sangria total não pode ser negativa.");
            if (e.ReforcoTotalCaixa < 0) r.AddError("Reforço total não pode ser negativo.");
            if (e.EnvelopeDinheiro < 0) r.AddError("Valor colocado no envelope não pode ser negativo.");
            if (e.PassagemCaixaDinheiro < 0) r.AddError("Valor da passagem de caixa não pode ser negativo.");
        }
    }
}
