using B3.Domain.Models;

namespace B3.Domain.Interfaces.Services
{
    public interface IFixedIncomeCalculatorService
    {
        public Task<bool> CalculateInvestmentAsync(Guid bankId, FinancialProductType type, decimal initialValue,
            int redemptionPeriod, int investmentDuration);
    }
}
