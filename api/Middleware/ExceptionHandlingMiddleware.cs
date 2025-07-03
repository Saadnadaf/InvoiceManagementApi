using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using api.Exceptions;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace api.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;
        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            int statusCode;
            string message;
            switch (exception)
            {
                case NotFoundException:
                    statusCode = (int)HttpStatusCode.NotFound;
                    message = exception.Message;
                    break;
                case BadRequestException:
                    statusCode = (int)HttpStatusCode.BadRequest;
                    message = exception.Message;
                    break;
                case ConflictException:
                    statusCode = (int)HttpStatusCode.Conflict;
                    message = exception.Message;
                    break;
                default:
                    statusCode = (int)HttpStatusCode.InternalServerError;
                    message = "An unexpected error occured";
                    break;
            }
            _logger.LogError(exception, "Error occured at {path} : {message}", context.Request.Path, message);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;

            var error = new
            {
                statusCode,
                message,
                path = context.Request.Path,
                timestamp = DateTime.Now
            };

            return context.Response.WriteAsync(JsonSerializer.Serialize(error));
        }
    }
}