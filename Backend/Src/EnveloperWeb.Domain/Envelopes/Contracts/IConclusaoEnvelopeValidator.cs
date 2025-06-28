using EnveloperWeb.Domain.Envelopes.Entities;
using EnveloperWeb.Domain.Shared.Validation;

namespace EnveloperWeb.Domain.Envelopes.Contracts
{
    public interface IConclusaoEnvelopeValidator
    {
        ValidationResult Validar(Envelope envelope);
    }
}
