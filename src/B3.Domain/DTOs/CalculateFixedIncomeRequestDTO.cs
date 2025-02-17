using B3.Domain.Models;

namespace B3.Domain.DTOs
{
    /// <summary>
    /// DTO para solicitação de cálculo de investimento em renda fixa.
    /// </summary>
    public class CalculateFixedIncomeRequestDTO
    {
        /// <summary>
        /// Identificador do banco associado ao investimento.
        /// </summary>
        public Guid BankId { get; set; }

        /// <summary>
        /// Tipo de produto financeiro a ser utilizado no cálculo.
        /// </summary>
        public FinancialProductType FinancialProductType { get; set; }

        /// <summary>
        /// Valor inicial investido.
        /// </summary>
        public decimal InitialValue { get; set; }

        /// <summary>
        /// Período de resgate do investimento em meses.
        /// </summary>
        public int RedemptionPeriod { get; set; }
    }
}
