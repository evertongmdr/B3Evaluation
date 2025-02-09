namespace B3.Application.DTOs
{
    public class FixedIncomeCalculationResultDTO
    {
        public decimal GrossAmount { get; set; }
        public decimal NetAmount { get; set; }
        public decimal ReturnAmount { get; set; }
        public decimal IncomeTaxAmount { get; set; }

        public FixedIncomeCalculationResultDTO(decimal grossAmount, decimal netAmount, decimal returnAmount, decimal incomeTaxAmount)
        {
            GrossAmount = grossAmount;
            NetAmount = netAmount;
            ReturnAmount = returnAmount;
            IncomeTaxAmount = incomeTaxAmount;
        }
    }
}
