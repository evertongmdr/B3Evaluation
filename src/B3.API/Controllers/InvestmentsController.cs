using B3.Application.Interfaces;
using B3.Application.Validators;
using B3.Common.API;
using B3.Common.Errors;
using B3.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace B3.API.Controllers
{
    public class InvestmentsController : MainController
    {
        private readonly ICalculateInvestmentService _calculateInvestmentService;
        public InvestmentsController(NotificationContext notificationContext,
            ICalculateInvestmentService calculateInvestmentService) : base(notificationContext)
        {
            _calculateInvestmentService = calculateInvestmentService;
        }

        [HttpPost("calculate-fixed-income")]
        [ProducesResponseType(typeof(ApiResponseWithData<FixedIncomeCalculationResultDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CalculateFixedIncome([FromBody] CalculateFixedIncomeRequestDTO request)
        {

            var validator = new CalculateFixedIncomeRequestValidator();
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid)
                return ErroResponse(validatorResult);
            
            var calculeFixedIncomeResult = await _calculateInvestmentService.CalculateFixedIncomeAsync(request);

            if (OperacaoValida())
                return SuccessResponseWithData(HttpStatusCode.OK , calculeFixedIncomeResult);

            return ErroResponse();


        }
       
    }
}
