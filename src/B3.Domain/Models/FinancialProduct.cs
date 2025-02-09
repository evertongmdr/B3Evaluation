namespace B3.Domain.Models
{
    public class FinancialProduct
    {
        public Guid Id { get; set; }
        public Guid BankId { get; set; }
        public FinancialProductType Type { get; set; }
        public decimal BaseRate { get; set; } // Exemplo: CDI para CDB, Selic para Tesouro, etc.
        public decimal TB { get; set; }

        public Bank Bank { get; set; }
    }
}