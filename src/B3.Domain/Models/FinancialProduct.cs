namespace B3.Domain.Models
{
    /// <summary>
    /// Representa um produto financeiro oferecido por um banco.
    /// </summary>
    public class FinancialProduct
    {
        public Guid Id { get; set; }

        public Guid BankId { get; set; }

        /// <summary>
        /// Tipo do produto financeiro (exemplo: CDB, Tesouro Direto, etc.).
        /// </summary>
        public FinancialProductType Type { get; set; }

        /// <summary>
        /// Taxa base utilizada no cálculo da rentabilidade do produto.
        /// Exemplo: CDI para CDB, Selic para Tesouro Direto.
        /// </summary>
        public decimal BaseRate { get; set; }

        /// <summary>
        /// Taxa que banco paga sobre o CDI
        /// </summary>
        public decimal TB { get; set; }

        public Bank Bank { get; set; }
    }
}