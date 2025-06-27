using EnveloperWeb.Domain.Envelopes.Entities;
using EnveloperWeb.Domain.Shared.Validation;

namespace EnveloperWeb.Domain.Envelopes.Services.RegrasConclusaoEnvelope
{
    public class ValidarSeJaFoiConferido : IConclusaoEnvelopeValidationRule
    {
        public void Validar(Envelope envelope, ValidationResult resultado)
        {
            if (envelope.EnvelopeConferido)
                resultado.AddError("O envelope já foi conferido e não pode ser alterado.");
        }
    }
}
