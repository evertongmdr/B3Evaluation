using B3.Application.DTOs;

namespace B3.Domain
{
    public class LciCalculatorStrategy : IFixedIncomeCalculatorStrategy
    {
        public FixedIncomeCalculationResultDTO CalculateFinancialDetails(decimal initialvalue, decimal cdiRate, decimal tb, int numberMonths)
        {
            throw new NotImplementedException();
        }
    }
}
