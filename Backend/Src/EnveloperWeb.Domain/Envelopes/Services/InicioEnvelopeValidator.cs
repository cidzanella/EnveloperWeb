using EnveloperWeb.Domain.Envelopes.Contracts;
using EnveloperWeb.Domain.Envelopes.Entities;
using EnveloperWeb.Domain.Envelopes.Services.RegrasInicioEnvelope;
using EnveloperWeb.Domain.Shared.Validation;

namespace EnveloperWeb.Domain.Envelopes.Services
{
    public class InicioEnvelopeValidator : IInicioEnvelopeValidator
    {
        private readonly IEnumerable<IInicioEnvelopeValidationRule> _regras;

        public InicioEnvelopeValidator(IEnumerable<IInicioEnvelopeValidationRule> regras)
        {
            _regras = regras;
        }

        public ValidationResult Validar(Envelope envelopeAtual, Envelope envelopeAnterior)
        {
            var resultado = new ValidationResult();

            foreach (var regra in _regras)
                regra.Validar(envelopeAtual, envelopeAnterior, resultado);

            return resultado;
        }
    }
}
