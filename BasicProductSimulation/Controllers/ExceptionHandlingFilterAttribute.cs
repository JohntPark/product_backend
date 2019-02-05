using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BasicProductSimulation.Controllers.Filters
{
    public class ExceptionHandlingFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var errorReferenceId = Guid.NewGuid().ToString();

            Console.WriteLine($"ErrorReferenceId: {errorReferenceId}, Exception message: {context.Exception.Message} StackTrace: {context.Exception.StackTrace}");

            if (context.Exception.GetType() == typeof(ArgumentException))
            {
                context.Result = new BadRequestObjectResult($"bad request error - reference id = {errorReferenceId}");
            }
            else
            {
                context.Result = new ObjectResult($"internal server error occured - reference id = {errorReferenceId}")
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError,

                };
            }

            base.OnException(context);
        }
    }
}
