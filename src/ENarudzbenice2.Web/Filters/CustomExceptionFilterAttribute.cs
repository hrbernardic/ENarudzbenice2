using System;
using System.Net;
using ENarudzbenice2.Application.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ENarudzbenice2.Web.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            context.HttpContext.Response.ContentType = "application/json";
            var code = HttpStatusCode.InternalServerError;

            switch (context.Exception.GetType().ToString())
            {
                case nameof(ValidationException):
                    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    context.Result = new JsonResult(((ValidationException)context.Exception).Failures);
                    return;
                case nameof(NotFoundException):
                    code = HttpStatusCode.NotFound;
                    break;
            }
            
            context.HttpContext.Response.StatusCode = (int)code;
            context.Result = new JsonResult(new
            {
                error = new
                {
                    userMessage = "Došlo je do neočekivane greške.",
                    systemMessage = context.Exception.Message
                }
            });
        }
    }
}
