using B3.Domain.Models;

namespace B3.Application.DTOs
{
    public class CalculateFixedIncomeRequestDTO
    {
        public Guid BankId { get; set; }
        public FinancialProductType FinancialProductType { get; set; }
        public decimal InitialVaue { get; set; }
        public int redemptionPeriod { get; set; }
        public int investmentDuration { get; set; }
    }
}
