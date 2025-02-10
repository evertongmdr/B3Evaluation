using B3.Application.Services;
using B3.Common.Errors;
using B3.Domain;
using B3.Domain.Models;
using B3.Tests.Application;
using Xunit.Sdk;

namespace B3.Tests.Domain
{
    public class CdbCalculatorStrategyTests
    {


        [Theory(DisplayName = "Teste que verifica se, o cálculo de investimento de renda fixa retorna os valores corretos")]
        [InlineData(1000, 0.009, 1.08, 12, 1)]
        [InlineData(1234, 0.009, 1.08, 24, 2)]
        [InlineData(1000.15, 0.009, 1.08, 25, 3)]
        public async Task CdbCalculatorStrategy_InputValid_ReturnsCorrectValue(decimal initialvalue, decimal cdiRate,
            decimal tb, int numberMonths, int numberTest)
        {
            //Arrange
            var cdbCalculatorStrategy = new CdbCalculatorStrategy();

            decimal expectedGrossAmount = 0, expectedNetAmount = 0, expectedReturnAmount = 0, expectedIncomeTaxAmount = 0;

            switch (numberTest)
            {
                case 1:

                    expectedGrossAmount = 1123.08M;
                    expectedNetAmount = 1098.46M;
                    expectedReturnAmount = 123.08M;
                    expectedIncomeTaxAmount = 24.62M;

                    break;

                case 2:

                    expectedGrossAmount = 1556.46M;
                    expectedNetAmount = 1500.03M;
                    expectedReturnAmount = 322.46M;
                    expectedIncomeTaxAmount = 56.43M;

                    break;

                case 3:

                    expectedGrossAmount = 1273.76M;
                    expectedNetAmount = 1232.72M;
                    expectedReturnAmount = 273.61M;
                    expectedIncomeTaxAmount = 41.04M;

                    break;
            }

            //Act

            var calculateFinancialResult = cdbCalculatorStrategy.CalculateFinancialDetails(initialvalue,
                cdiRate, tb, numberMonths);

            //Assert

            Assert.Equal(expectedGrossAmount, calculateFinancialResult.GrossAmount);
            Assert.Equal(expectedNetAmount, calculateFinancialResult.NetAmount);
            Assert.Equal(expectedReturnAmount, calculateFinancialResult.ReturnAmount);
            Assert.Equal(expectedIncomeTaxAmount, calculateFinancialResult.IncomeTaxAmount);

        }

    }


}
