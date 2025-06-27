using EnveloperWeb.Domain.Envelopes.Entities;
using EnveloperWeb.Domain.Shared.Validation;

namespace EnveloperWeb.Domain.Envelopes.Services.RegrasConclusaoEnvelope
{
    public class ValidarEnvelopeMaisRepasse : IConclusaoEnvelopeValidationRule
    {
        public void Validar(Envelope e, ValidationResult r)
        {
            var soma = e.EnvelopeDinheiro + e.PassagemCaixaDinheiro;
            var diferenca = Math.Round(e.DinheiroFinal - soma, 2);

            if (diferenca != 0)
                r.AddError($"Valor final ({e.DinheiroFinal:F2}) não bate com envelope ({e.EnvelopeDinheiro:F2}) + repasse ({e.PassagemCaixaDinheiro:F2}).");
        }
    }
}