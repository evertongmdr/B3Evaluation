using B3.Domain.DTOs;

namespace B3.Domain.Models
{
    public class LciCalculatorStrategy : IFixedIncomeCalculatorStrategy
    {
        public FixedIncomeCalculationResultDTO CalculateFinancialDetails(decimal initialvalue, decimal cdiRate, decimal tb, int numberMonths)
        {
            throw new NotImplementedException();
        }
    }
}
