namespace B3.Domain.Models
{
    public class Bank
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public List<FinancialProduct> FinancialProducts { get; set; } = new();


        public static Bank Initiate()
        {
            return new Bank
            {
                Id = Guid.NewGuid(),
                Name = "Banco B3 S.A.",
                Code = "096",

                FinancialProducts = new List<FinancialProduct>
                {
                    new FinancialProduct
                    {
                        Type = FinancialProductType.CDB,
                        BaseRate = 0.009M,
                        TB = 1.08M
                    },
                    new FinancialProduct
                    {
                        Type = FinancialProductType.LCI,
                        BaseRate = 0.010M,
                        TB = 1.10M
                    }
                }
            };
        }
    }
}