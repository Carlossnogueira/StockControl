using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using StockControl.Communication.Response;
using StockControl.Exception;

namespace StockControl.Api.Filter
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if(context.Exception is StockControlExceptionBase)
            {
                HandleProjectException(context);
            } else
            {
                ThrowUnkowError(context);
            }

        }

        private void HandleProjectException(ExceptionContext context) 
        { 
            var exception = (StockControlExceptionBase)context.Exception;
            var errorResponse = new ErrorResponse(exception.GetErrors()); 
            context.HttpContext.Response.StatusCode = exception.StatusCode;
            context.Result = new ObjectResult(errorResponse);
        }

        private void ThrowUnkowError(ExceptionContext context)
        {
            var errorResponse = new ErrorResponse("Erro interno no servidor!");

            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Result = new ObjectResult(errorResponse);
        }
    }
}
