using B3.Domain.DTOs;

namespace B3.Domain.Models
{

    /// <summary>
    /// Define a estratégia para cálculo de investimentos em renda fixa.
    /// </summary>
    public interface IFixedIncomeCalculatorStrategy
    {
        /// <summary>
        /// Calcula os detalhes financeiros do investimento em renda fixa.
        /// </summary>
        FixedIncomeCalculationResultDTO CalculateFinancialDetails(decimal initialValue, decimal cdiRate, decimal tb, int numberMonths);
    }
}
