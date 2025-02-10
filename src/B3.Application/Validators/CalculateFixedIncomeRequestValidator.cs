using B3.Domain.DTOs;
using FluentValidation;

namespace B3.Application.Validators
{
    public class CalculateFixedIncomeRequestValidator : AbstractValidator<CalculateFixedIncomeRequestDTO>
    {
        public CalculateFixedIncomeRequestValidator()
        {

            RuleFor(b => b.BankId)
             .NotEmpty().WithMessage("O identificador do banco deve ser informado");

            RuleFor(x => x.InitialValue).GreaterThan(0)
                .WithMessage("O valor inicial deve ser maior que zero");

            RuleFor(x => x.InvestmentDuration).GreaterThan(1)
                .WithMessage("O número de meses para o resgate da aplicação deve ser maior que 1");
        }
    }
}
