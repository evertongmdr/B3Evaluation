using B3.Domain.DTOs;

namespace B3.Application.Interfaces
{
    /// <summary>
    /// Define os serviços de cálculo de investimentos.
    /// </summary>
    public interface ICalculateInvestmentService
    {
        /// <summary>
        /// Calcula o investimento em renda fixa com base nos parâmetros fornecidos.
        /// </summary>
        /// <param name="FixedIncoeCalculateRequest">Objeto contendo os dados necessários para o cálculo.</param>
        /// <returns>Um <see cref="FixedIncomeCalculationResultDTO"/> contendo os resultados do cálculo ou null se houver erro.</returns>
        public Task<FixedIncomeCalculationResultDTO?> CalculateFixedIncomeAsync(CalculateFixedIncomeRequestDTO FixedIncoeCalculateRequest);

        /// <summary>
        /// Calcula o investimento em renda variável.
        /// </summary>
        /// <returns>Uma <see cref="Task"/> representando a operação assíncrona.</returns>
        public Task CalculateVariableIncomeAsync();
    }
}
