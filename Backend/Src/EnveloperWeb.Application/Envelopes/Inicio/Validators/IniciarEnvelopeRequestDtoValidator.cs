using FluentValidation;
using EnveloperWeb.Application.Envelopes.Inicio.DTOs;

namespace EnveloperWeb.Application.Envelopes.Inicio.Validators
{
    public class IniciarEnvelopeRequestDtoValidator : AbstractValidator<IniciarEnvelopeRequestDto>
    {
        // FLuentValidation: valida no controller (via [ApiController] + ModelState)
        public IniciarEnvelopeRequestDtoValidator()
        {
            RuleFor(x => x.PDVId)
                .GreaterThan(0).WithMessage("O PDVId deve ser informado.");

            RuleFor(x => x.OperadorId)
                .GreaterThan(0).WithMessage("O OperadorId deve ser informado.");

            RuleFor(x => x.DataHoraInicio)
                .LessThanOrEqualTo(DateTime.Now).WithMessage("A data/hora de início não pode estar no futuro.");

            RuleFor(x => x.DinheiroInicial)
                .GreaterThanOrEqualTo(0).WithMessage("O valor do dinheiro inicial deve ser maior ou igual a zero.");
        }
    }
}
