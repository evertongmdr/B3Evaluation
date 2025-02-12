namespace B3.Domain.DTOs
{
    /// <summary>
    /// Representa o resultado do cálculo de um investimento em renda fixa.
    /// </summary>
    public class FixedIncomeCalculationResultDTO
    {
        /// <summary>
        /// Obtém ou define o valor bruto total do investimento.
        /// </summary>
        public decimal GrossAmount { get; set; }

        /// <summary>
        /// Obtém ou define o valor líquido do investimento após a tributação.
        /// </summary>
        public decimal NetAmount { get; set; }

        /// <summary>
        /// Obtém ou define o valor do rendimento obtido com o investimento.
        /// </summary>
        public decimal ReturnAmount { get; set; }

        /// <summary>
        /// Obtém ou define o valor do imposto de renda.
        /// </summary>
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
