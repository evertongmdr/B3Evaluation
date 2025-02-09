using B3.Application.DTOs;

namespace B3.Application.Interfaces
{
    public interface ICalculateInvestmentService
    {
        public Task<FixedIncomeCalculationResultDTO?> CalculateFixedIncomeAsync(CalculateFixedIncomeRequestDTO FixedIncoeCalculateRequest);

        public Task CalculateVariableIncomeAsync();
        
    }
}
