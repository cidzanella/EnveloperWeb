using EnveloperWeb.Domain.Envelopes.Entities;
using EnveloperWeb.Domain.Shared.Validation;

namespace EnveloperWeb.Domain.Envelopes.Services.RegrasConclusaoEnvelope
{
    public interface IConclusaoEnvelopeValidationRule
    {
        void Validar(Envelope envelope, ValidationResult resultado);
    }
}
