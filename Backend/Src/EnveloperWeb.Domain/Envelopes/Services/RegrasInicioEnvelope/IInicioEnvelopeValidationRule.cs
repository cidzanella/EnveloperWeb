using EnveloperWeb.Domain.Envelopes.Entities;
using EnveloperWeb.Domain.Shared.Validation;

namespace EnveloperWeb.Domain.Envelopes.Services.RegrasInicioEnvelope
{
    public interface IInicioEnvelopeValidationRule
    {
        void Validar(Envelope envelopeAtual, Envelope envelopeAnterior, ValidationResult resultado);
    }
}
