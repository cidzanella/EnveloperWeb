using EnveloperWeb.Application.Envelopes.Conclusao.DTOs;
using FluentValidation;
using System;

namespace EnveloperWeb.Application.Envelopes.Conclusao.Validators
{
    public class ConcluirEnvelopeRequestDtoValidator : AbstractValidator<ConcluirEnvelopeRequestDto>
    {
        // FLuentValidation: valida no controller (via [ApiController] + ModelState)
        public ConcluirEnvelopeRequestDtoValidator()
        {
            RuleFor(x => x.EnvelopeId)
                .GreaterThan(0).WithMessage("O ID do envelope deve ser informado.");

            RuleFor(x => x.DinheiroFinal)
                .GreaterThanOrEqualTo(0).WithMessage("O dinheiro final deve ser maior ou igual a zero.");

            RuleFor(x => x.FaturamentoTotalVendas)
                .GreaterThanOrEqualTo(0).WithMessage("O faturamento deve ser maior ou igual a zero.");

            RuleFor(x => x.DataHoraFechamento)
                .LessThanOrEqualTo(DateTime.Now).WithMessage("A data de fechamento não pode estar no futuro.");

            RuleFor(x => x.ClimaId)
                .GreaterThan(0).WithMessage("O clima deve ser informado.");

            RuleFor(x => x.TemperaturaTurno)
                .InclusiveBetween(0, 50).WithMessage("A temperatura deve estar entre 0 e 50 ºC.");
        }
    }
}
