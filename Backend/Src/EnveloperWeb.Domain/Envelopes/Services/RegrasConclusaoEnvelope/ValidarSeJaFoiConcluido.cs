using EnveloperWeb.Domain.Envelopes.Entities;
using EnveloperWeb.Domain.Shared.Validation;

namespace EnveloperWeb.Domain.Envelopes.Services.RegrasConclusaoEnvelope
{

    public class ValidarSeJaFoiConcluido : IConclusaoEnvelopeValidationRule
    {
        public void Validar(Envelope envelope, ValidationResult resultado)
        {
            if (envelope.DataHoraConclusao != null)
                resultado.AddError("O envelope já foi concluído.");
        }
    }
}