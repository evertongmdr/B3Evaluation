namespace B3.Domain.Models
{
    public class Bank
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public List<FinancialProduct> FinancialProducts { get; set; } = new();
    }
}