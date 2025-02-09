
using B3.Application.DTOs;
using B3.Application.Interfaces;
using B3.Common.Domain;
using B3.Common.Errors;
using B3.Domain;
using B3.Domain.Interfaces.Repositories;
using B3.Domain.Models;
using System.Net;

namespace B3.Application.Services
{
    public class CalculateInvestmentService : Service, ICalculateInvestmentService
    {
        private readonly IBankRepository _bankRepository;
        private readonly IFinancialProductRepository _financialProductRepository;

        public CalculateInvestmentService(NotificationContext notificationContext, IBankRepository bankRepository,
            IFinancialProductRepository financialProductRepository) : base(notificationContext)
        {
            _bankRepository = bankRepository;
            _financialProductRepository = financialProductRepository;
        }

        public async Task<FixedIncomeCalculationResultDTO?> CalculateFixedIncomeAsync(CalculateFixedIncomeRequestDTO request)
        {
            var defaultErrorMessage = "se o problema persistir entre em contato com o time de suporte.";

            var bank = await _bankRepository.GetByIdAsync(request.BankId);

            if (bank == null)
            {
                _notificationContext.AddNotificacao($"Banco não encontrado, {defaultErrorMessage}", HttpStatusCode.NotFound);

                return null;
            }

            var financialProduct = await _financialProductRepository.FirstAsync(x => x.BankId == request.BankId &&
                 x.Type == request.FinancialProductType);

            if (financialProduct == null)
            {
                _notificationContext.AddNotificacao($"Produto financeiro de investimento não encontrado, " +
                    $"{defaultErrorMessage}", HttpStatusCode.NotFound);

                return null;
            }

            IFixedIncomeCalculatorStrategy fixedIncomeCalculatorStrategy;

            switch (financialProduct.Type)
            {
                case FinancialProductType.CDB:
                    fixedIncomeCalculatorStrategy = new CdbCalculatorStrategy();
                    break;

                case FinancialProductType.LCI:
                    fixedIncomeCalculatorStrategy = new LciCalculatorStrategy();
                    break;

                default:
                    _notificationContext.AddNotificacao($"Produto financeiro de investimento " +
                        $"não esta mapeado em nosso sistema, {defaultErrorMessage}", HttpStatusCode.NotFound);

                    return null;

            }

            var calculateFinancialResult = fixedIncomeCalculatorStrategy.CalculateFinancialDetails(request.InitialVaue,
                financialProduct.BaseRate, financialProduct.TB, request.investmentDuration);

            return calculateFinancialResult;

        }

        public Task CalculateVariableIncomeAsync()
        {
            throw new NotImplementedException();
        }
    }

}
