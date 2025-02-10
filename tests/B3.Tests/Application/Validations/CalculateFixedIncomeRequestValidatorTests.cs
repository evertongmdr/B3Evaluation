using B3.Application.Validators;
using B3.Domain.DTOs;

namespace B3.Tests.Application.Validations
{
    public class CalculateFixedIncomeRequestValidatorTests
    {
        private readonly CalculateFixedIncomeRequestValidator _validator;

        public CalculateFixedIncomeRequestValidatorTests()
        {
            _validator = new CalculateFixedIncomeRequestValidator();
        }

        [Fact(DisplayName = "Teste que verifica se, quando banco é nulo, o retorno é inválido com message de erro")]
        public void CalculateFixedIncomeRequestValidator_BankIdIsNull_ReturnsInvalidWithErrorMessage()
        {
            // Arrange

            var calculateFixedIncomeRequest = new CalculateFixedIncomeRequestDTO
            {
                BankId = Guid.Empty,
                InitialValue = 1000,
                InvestmentDuration = 12

            };

            //Act

            var validationResult = _validator.Validate(calculateFixedIncomeRequest);

            //Asert

            Assert.False(validationResult.IsValid);
            Assert.Single(validationResult.Errors);
            Assert.Equal("O identificador do banco deve ser informado", validationResult.Errors.First().ErrorMessage);

        }

        [Fact(DisplayName = "Teste que verifica se, quando valor incial não é maior que zero, " +
            "o retorno é inválido com message de erro")]
        public void CalculateFixedIncomeRequestValidator_InitialvalueGreaterThanZero_ReturnsInvalidWithErrorMessage()
        {
            // Arrange
            var calculateFixedIncomeRequest = new CalculateFixedIncomeRequestDTO
            {
                BankId = Guid.NewGuid(),
                InitialValue = 0,
                InvestmentDuration = 12
            };

            //Act

            var validationResult = _validator.Validate(calculateFixedIncomeRequest);

            //Asert

            Assert.False(validationResult.IsValid);
            Assert.Single(validationResult.Errors);
            Assert.Equal("O valor inicial deve ser maior que zero", validationResult.Errors.First().ErrorMessage);

        }

        [Fact(DisplayName = "Teste que verifica se, quando o número de meses não é maior que 1, " +
            "o retorno é inválido com message de erro")]
        public void CalculateFixedIncomeRequestValidator_investmentDurationGreaterThanOne_ReturnInvalidWithErrorMessage()
        {
            // Arrange
            var calculateFixedIncomeRequest = new CalculateFixedIncomeRequestDTO
            {
                BankId = Guid.NewGuid(),
                InitialValue = 1000,
                InvestmentDuration = 0
            };

            //Act

            var validationResult = _validator.Validate(calculateFixedIncomeRequest);

            //Asert

            Assert.False(validationResult.IsValid);
            Assert.Single(validationResult.Errors);
            Assert.Equal("O número de meses para o resgate da aplicação deve ser maior que 1", validationResult.Errors.First().ErrorMessage);

        }

        [Fact(DisplayName = "Teste que verifica se, quando a entrada é válida, " +
            "o retorno é válido sem message de erro")]
        public void CalculateFixedIncomeRequestValidator_ValidInput_ReturnsValidWithoutErrorMessage()
        {
            // Arrange
            var calculateFixedIncomeRequest = new CalculateFixedIncomeRequestDTO
            {
                BankId = Guid.NewGuid(),
                InitialValue = 1000,
                InvestmentDuration = 12
            };

            //Act

            var validationResult = _validator.Validate(calculateFixedIncomeRequest);

            //Asert

            Assert.True(validationResult.IsValid);
            Assert.Empty(validationResult.Errors);
        }
    }
}
