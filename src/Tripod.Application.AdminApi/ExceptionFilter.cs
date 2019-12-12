using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Tripod.Application.AdminApi
{
    public class ExceptionFilter : IActionFilter, IOrderedFilter
    {
        public int Order => int.MaxValue - 10;

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is ApiException exception)
            {
                var response = new Response<object>(){
                  Code = exception.Code,
                  Message = exception.Message  
                };
                context.Result = new ObjectResult(response)
                {
                    StatusCode = 200,
                };
            }else if(context.Exception is Exception)
            {
                var response = new Response<object>(){
                  Code = 0,
                  Message ="系统异常"
                };
                context.Result = new ObjectResult(response)
                {
                    StatusCode = 500,
                };
            }
            context.ExceptionHandled = true;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            
        }
    }
}