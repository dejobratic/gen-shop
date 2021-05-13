using GenShop.Invoicing.Contract.Responses;
using GenShop.Invoicing.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace ProShop.Web.Filters
{
    public class ExceptionHandlingFilter :
        IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            context.Result = CreateResult(context.Exception);
        }

        private static IActionResult CreateResult(Exception ex)
        {
            switch (ex)
            {
                case EntityNotFoundException entityNotFoundEx:
                    return entityNotFoundEx.ToNotFound();

                case EntityAlreadyExistsException entityExistsEx:
                    return entityExistsEx.ToConflict();

                default:
                    return ex.ToServerError();
            }
        }
    }

    static class ExceptionExtensions
    {
        public static IActionResult ToNotFound(this Exception ex)
            => new NotFoundObjectResult(CreateErrorResponse(ex));

        public static IActionResult ToConflict(this Exception ex)
            => new ConflictObjectResult(CreateErrorResponse(ex));

        public static IActionResult ToServerError(this Exception ex)
            => new ObjectResult(CreateErrorResponse(ex)) { StatusCode = 500 };

        private static ErrorResponse CreateErrorResponse(Exception ex)
            => new ErrorResponse { Message = ex.Message };
    }
}