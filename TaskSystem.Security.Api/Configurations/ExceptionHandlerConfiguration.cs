using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Security.Api.Configurations
{
    public class ExceptionHandlerConfiguration
    {
        public async Task Invoke(HttpContext context)
        {
            var httpStatus = HttpStatusCode.InternalServerError;

            var exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;
            if (exception != null)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)httpStatus;

                await context.Response.WriteAsync(JsonConvert.SerializeObject(new
                {
                    ErroMessage = exception.StackTrace,
                    Status = httpStatus
                }));
            }
        }
    }
}
