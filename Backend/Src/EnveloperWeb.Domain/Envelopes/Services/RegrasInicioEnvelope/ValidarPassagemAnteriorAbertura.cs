using EnveloperWeb.Domain.Envelopes.Entities;
using EnveloperWeb.Domain.Shared.Validation;

namespace EnveloperWeb.Domain.Envelopes.Services.RegrasInicioEnvelope
{
    public class ValidarPassagemAnteriorAbertura : IInicioEnvelopeValidationRule
    {
        public void Validar(Envelope envelopeAtual, Envelope envelopeAnterior, ValidationResult resultado)
        {
            if (envelopeAnterior == null)
                return;

            if (envelopeAtual.DinheiroInicial != envelopeAnterior.PassagemCaixaDinheiro)
            {
                resultado.AddError($"O valor do dinheiro inicial informado ({envelopeAtual.DinheiroInicial:C}) não confere com o valor da passagem de caixa do envelope anterior ({envelopeAnterior.PassagemCaixaDinheiro:C}).");
            }
        }
    }
}
