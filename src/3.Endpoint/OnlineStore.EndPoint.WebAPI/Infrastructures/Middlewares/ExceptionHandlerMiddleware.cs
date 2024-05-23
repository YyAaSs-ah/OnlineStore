using Microsoft.EntityFrameworkCore;
using OnlineStore.Core.RequestResponse.Common;
using System;

namespace OnlineStore.EndPoint.WebAPI.Infrastructures.Middlewares;

public class ExceptionHandlerMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
{

    public async Task Invoke(HttpContext httpContext)
    {
        try
        {
            await next(httpContext);
        }
        catch (ApplicationException ex)
        {
            var logger = loggerFactory.CreateLogger<ExceptionHandlerMiddleware>();
            logger.LogError(ex.Message, ex);

            var result = new Result();
            result.AddError(ex.Message);

            await httpContext.Response.WriteAsJsonAsync(result);
        }
        catch (Exception ex)
        {
            var logger = loggerFactory.CreateLogger<ExceptionHandlerMiddleware>();
            logger.LogError(ex.Message, ex);

            var result = new Result();
            result.AddError("System Exception");

            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            await httpContext.Response.WriteAsJsonAsync(result);
        }
    }
}
