﻿
using Restaurants.Domain.Exceptions;

namespace Restaurants.API.Middlewares
{
    public class ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> _logger) : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
			try
			{
				await next.Invoke(context);
			}
			catch (NotFoundException ex)
			{
                context.Response.StatusCode = 404;
                await context.Response.WriteAsync(ex.Message);
            }
			catch (Exception ex)
			{
				_logger.LogError(ex, ex.Message);
				context.Response.StatusCode = 500;
				await context.Response.WriteAsync("Ups...Something went wrong");
			}
        }
    }
}
