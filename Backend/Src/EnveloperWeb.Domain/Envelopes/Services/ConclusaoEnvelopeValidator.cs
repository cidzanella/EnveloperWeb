using EnveloperWeb.Domain.Envelopes.Contracts;
using EnveloperWeb.Domain.Envelopes.Entities;
using EnveloperWeb.Domain.Envelopes.Services.RegrasConclusaoEnvelope;
using EnveloperWeb.Domain.Shared.Validation;

namespace EnveloperWeb.Domain.Envelopes.Services
{
    public class ConclusaoEnvelopeValidator : IConclusaoEnvelopeValidator
    {
        private readonly IEnumerable<IConclusaoEnvelopeValidationRule> _regras;

        //Validador agregador
        public ConclusaoEnvelopeValidator(IEnumerable<IConclusaoEnvelopeValidationRule> regras)
        {
            _regras = regras;
        }

        public ValidationResult Validar(Envelope envelope)
        {
            var resultado = new ValidationResult();

            foreach (var regra in _regras)
                regra.Validar(envelope, resultado);

            return resultado;
        }
    }
}
