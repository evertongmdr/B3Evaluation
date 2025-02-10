using B3.Application.Services;
using B3.Common.Errors;
using B3.Domain.Interfaces.Repositories;
using B3.Domain.Models;
using Microsoft.Extensions.DependencyModel;
using Moq;
using Moq.AutoMock;
using System.Linq.Expressions;

namespace B3.Tests.Application
{
    [Collection(nameof(CalculateInvestmentCollection))]
    public class CalculateInvestmentServiceTests
    {
        private readonly AutoMocker _mocker;

        private readonly CalculateInvestimentFixture _calculateInvestimentFixture;
        private readonly Mock<IBankRepository> _bankRepositoryMock;
        private readonly Mock<IFinancialProductRepository> _financialProductRepository;

        private readonly NotificationContext _notificationContext;

        public CalculateInvestmentServiceTests(CalculateInvestimentFixture calculateInvestimentFixture)
        {
            _mocker = new AutoMocker();

            _calculateInvestimentFixture = calculateInvestimentFixture;
            _notificationContext = new NotificationContext();

            _mocker.Use(_notificationContext);
            _bankRepositoryMock = _mocker.GetMock<IBankRepository>();
            _financialProductRepository = _mocker.GetMock<IFinancialProductRepository>();
        }

        [Fact(DisplayName = "Teste que verifica se, quando o banco não é encontrado, " +
            "o retorno é nulo com uma mensagem de erro")]
        public async Task CalculateFixedIncome_BankNotFound_ReturnsNullWithErrorMessage()
        {
            //Arrange

            var request = _calculateInvestimentFixture.GenerateValidFixedIncomeInvestmentRequest();

            var calculateInvestmentService = _mocker.CreateInstance<CalculateInvestmentService>();

            _bankRepositoryMock.Setup(rb => rb.GetByIdAsync(request.BankId)).ReturnsAsync((Bank?)null);

            //Act

            var fixedIncomeCalculationResul = await calculateInvestmentService.CalculateFixedIncomeAsync(request);

            //Assert

            Assert.Null(fixedIncomeCalculationResul);
            Assert.Single(_notificationContext.Notifications);
            Assert.Contains("Banco não encontrado", _notificationContext.Notifications.First().Message);

        }


        [Fact(DisplayName = "Teste que verifica se, quando o Produto Financeiro não é encontrado, " +
             "o retorno é nulo com uma mensagem de erro")]
        public async Task CalculateFixedIncome_FinancialProduct_ReturnsNullWithErrorMessage()
        {
            //Arrange

            var request = _calculateInvestimentFixture.GenerateValidFixedIncomeInvestmentRequest();

            var calculateInvestmentService = _mocker.CreateInstance<CalculateInvestmentService>();

            _bankRepositoryMock.Setup(x => x.GetByIdAsync(request.BankId)).ReturnsAsync(new Bank());

            _financialProductRepository
                .Setup(x => x.FirstAsync(It.IsAny<Expression<Func<FinancialProduct, bool>>>()))
                .ReturnsAsync((FinancialProduct?)null);

            //Act

            var fixedIncomeCalculationResul = await calculateInvestmentService.CalculateFixedIncomeAsync(request);

            //Assert

            Assert.Null(fixedIncomeCalculationResul);
            Assert.Single(_notificationContext.Notifications);
            Assert.Contains("Produto financeiro de investimento não encontrado", 
                _notificationContext.Notifications.First().Message);

        }


        [Fact(DisplayName = "Teste que verifica se, quando o Produto Financeiro não está mepeado no sitema, " +
             "o retorno é nulo com uma mensagem de erro")]
        public async Task CalculateFixedIncome_NotMappedFinacialProduct_ReturnsNullWithErrorMessage()
        {
            //Arrange

            var request = _calculateInvestimentFixture.GenerateValidFixedIncomeInvestmentRequest();

            request.FinancialProductType = FinancialProductType.LCA;

            var bank = new Bank
            {
                Id = Guid.NewGuid()
            };

            var financialProduct = new FinancialProduct
            {
                Id = Guid.NewGuid(),
                BankId = bank.Id,
                Type = FinancialProductType.LCA,
                BaseRate = 0.009M,
                TB = 1.08M
            };

            var calculateInvestmentService = _mocker.CreateInstance<CalculateInvestmentService>();

            _bankRepositoryMock.Setup(x => x.GetByIdAsync(request.BankId)).ReturnsAsync(bank);

            _financialProductRepository
                .Setup(x => x.FirstAsync(It.IsAny<Expression<Func<FinancialProduct, bool>>>()))
                .ReturnsAsync(financialProduct);

            //Act

            var fixedIncomeCalculationResul = await calculateInvestmentService.CalculateFixedIncomeAsync(request);

            //Assert

            Assert.Null(fixedIncomeCalculationResul);
            Assert.Single(_notificationContext.Notifications);
            Assert.Contains("Produto financeiro de investimento não está mapeado em nosso sistema",
                _notificationContext.Notifications.First().Message);
        }


        [Fact(DisplayName = "Teste que verifica se, quando a entrada é válida, " +
            "retorna o cálculo de investimento de renda fixa com sucesso")]
        public async Task CalculateFixedIncome_ValidInput_ReturnsFixedIncomeInvestmentCalculationsuccess()
        {
            //Arrange

            var request = _calculateInvestimentFixture.GenerateValidFixedIncomeInvestmentRequest();

            var bank = new Bank
            {
                Id = Guid.NewGuid()
            };

            var financialProduct = new FinancialProduct
            {
                Id = Guid.NewGuid(),
                BankId = bank.Id,
                Type = FinancialProductType.CDB,
                BaseRate = 0.009M,
                TB = 1.08M
            };

            var calculateInvestmentService = _mocker.CreateInstance<CalculateInvestmentService>();

            _bankRepositoryMock.Setup(x => x.GetByIdAsync(request.BankId)).ReturnsAsync(bank);

            _financialProductRepository
                .Setup(x => x.FirstAsync(It.IsAny<Expression<Func<FinancialProduct, bool>>>()))
                .ReturnsAsync(financialProduct);

            //Act

            var fixedIncomeCalculationResul = await calculateInvestmentService.CalculateFixedIncomeAsync(request);

            //Assert

            Assert.NotNull(fixedIncomeCalculationResul);
            Assert.False(_notificationContext.ExistNotifications);
        }
    }
}
