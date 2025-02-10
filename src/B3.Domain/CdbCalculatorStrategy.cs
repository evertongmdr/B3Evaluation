using B3.Domain.DTOs;

namespace B3.Domain.Models
{
    public class CdbCalculatorStrategy : IFixedIncomeCalculatorStrategy
    {

        public FixedIncomeCalculationResultDTO CalculateFinancialDetails(decimal initialvalue, decimal cdiRate, 
            decimal tb, int numberMonths)
        {
            
            var totalValue = CalculateCdbYield(initialvalue,cdiRate,tb);

            for (int i = 1; i < numberMonths; i++)
                totalValue = CalculateCdbYield(totalValue, cdiRate, tb);

            totalValue = Math.Round(totalValue, 2);

            var returnAmount = totalValue - initialvalue;
            returnAmount = Math.Round(returnAmount, 2);

            var incomeTaxAmount = returnAmount * GetTaxRateValue(numberMonths);
            incomeTaxAmount = Math.Round(incomeTaxAmount, 2);

            var netAmount = totalValue - incomeTaxAmount;
            netAmount = Math.Round(netAmount,2);

            return new FixedIncomeCalculationResultDTO(totalValue, netAmount,
                returnAmount, incomeTaxAmount);
           
        }

        public decimal GetTaxRateValue(int numberMonths)
        {
            if (numberMonths <= 6) return 0.225M;

            if (numberMonths <= 12) return 0.20M;

            if (numberMonths <= 24) return 0.175M;
            
            return 0.15M;
        }

        private decimal CalculateCdbYield(decimal value, decimal cdiRate, decimal tb)
        {
           return value * (1 + cdiRate * tb);
        }


    }
}
