﻿using B3.Domain.DTOs;
using B3.Domain.Models;

namespace B3.Tests.Application
{
    [CollectionDefinition(nameof(CalculateInvestmentCollection))]
    public class CalculateInvestmentCollection : ICollectionFixture<CalculateInvestimentFixture> { }

    public class CalculateInvestimentFixture : IDisposable
    {
        public CalculateFixedIncomeRequestDTO GenerateValidFixedIncomeInvestmentRequest()
        {
            return new CalculateFixedIncomeRequestDTO
            {
                BankId = Guid.NewGuid(),
                FinancialProductType = FinancialProductType.CDB,
                InitialValue = 1000M,
                investmentDuration = 12,
                redemptionPeriod = 6,
            };
        }

        public void Dispose()
        {

        }
    }





}
