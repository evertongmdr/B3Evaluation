using B3.Common.Errors;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace B3.Common.API
{
    public abstract class MainController : ControllerBase
    {
        protected readonly NotificationContext _notificationContext;

        public MainController(NotificationContext notificationContext)
        {
            _notificationContext = notificationContext;
        }

        protected bool OperacaoValida()
        {
            return !_notificationContext.ExistNotifications;
        }

        protected ActionResult SuccessResponse(HttpStatusCode statusCode)
        {
            var result = new ApiResponse
            {
                Success = true,
                Errors = null,
            };

            return StatusCode((int)statusCode, result);
        }

        protected ActionResult SuccessResponseWithData<T>(HttpStatusCode statusCode, T data)
        {
            var result = new ApiResponseWithData<T>
            {
                Success = true,
                Errors = null,
                Data = data
            };

            return StatusCode((int)statusCode, result);
        }

        protected ActionResult ErroResponse(ValidationResult? validationResult = null)
        {
            if (validationResult != null)
                _notificationContext.AddNotifications(validationResult);

            var codigoErro = (int)_notificationContext.Notifications.Select(n => n.ErroCode).First();

            var result = new ApiResponse()
            {
                Success = false,
                Errors = _notificationContext.Notifications.Select(n => n.Message).ToList(),
            };

            return StatusCode(codigoErro, result);
        }

    }
}
