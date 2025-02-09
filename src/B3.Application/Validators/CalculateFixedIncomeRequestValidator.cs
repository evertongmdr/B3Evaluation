using FluentValidation;

namespace B3.Application.DTOs.Validators
{
    public class CalculateFixedIncomeRequestValidator : AbstractValidator<CalculateFixedIncomeRequestDTO>
    {
        public CalculateFixedIncomeRequestValidator()
        {

            RuleFor(b => b.BankId)
             .NotEmpty().WithMessage("O identificador do banco deve ser informado");

            RuleFor(x => x.InitialVaue).GreaterThan(0)
                .WithMessage("O valor inicial deve ser maior que zero");

            RuleFor(x => x.investmentDuration).GreaterThan(1)
                .WithMessage("O número de meses para o resgate da aplicação deve ser maior que 1");
        }
    }
}
