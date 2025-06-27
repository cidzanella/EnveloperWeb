using EnveloperWeb.Domain.Envelopes.Entities;
using EnveloperWeb.Domain.Shared.Validation;

namespace EnveloperWeb.Domain.Envelopes.Services.RegrasInicioEnvelope
{
    public class ValidarValorInicial : IInicioEnvelopeValidationRule
    {
        public void Validar(Envelope envelopeAtual, Envelope envelopeAnterior, ValidationResult resultado)
        {
            if (envelopeAtual.DinheiroInicial < 0)
                resultado.AddError("O valor do dinheiro inicial não pode ser negativo.");
        }
    }
}
