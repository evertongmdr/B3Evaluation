using B3.Application.DTOs;

namespace B3.Domain
{
    /// <summary>
    /// ICalculadoraRendaFixa, Define uma estratégia para calcular o rendimento de investimentos em renda fixa.
    /// </summary>
    public interface IFixedIncomeCalculatorStrategy // =>ICalculadoraRendaFixa
    {
        /// <summary>
        /// Calcula o rendimento de um investimento em renda fixa.
        /// </summary>
        /// <param name="initialValue">O valor inicial investido.</param>
        FixedIncomeCalculationResultDTO CalculateFinancialDetails(decimal initialvalue, decimal cdiRate, decimal tb, int numberMonths);
    }
}
