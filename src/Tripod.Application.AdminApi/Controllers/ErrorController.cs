using System;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Tripod.Application.AdminApi.Controllers
{
    [ApiController]
    public class ErrorController : ControllerBase
    {
        [HttpGet]
        [Route("/error")]
        public IActionResult Error([FromServices] IWebHostEnvironment webHostEnvironment)
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var exception = context.Error;

            var response = new Response();
            if (exception is ApiException)
            {
                var apiException = exception as ApiException;
                response.Code = apiException.Code;
                response.Message = apiException.Message;
            }
            else if (exception is Exception)
            {
                response.Code = 0;
                response.Message = "系统异常";

                // NOTE Only show the exception infomation in Development Enviroment.
                if (webHostEnvironment.EnvironmentName == "Development")
                {
                    response.Message = exception.Message;
                    response.Data = exception.ToString();
                }
                else
                {
                    response.Message = "系统异常";
                    // TODO record the exception detail.
                }
            }
            return new ObjectResult(response);
        }
    }
}