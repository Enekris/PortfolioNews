using InfoPortal.Api.Models.Response;
using InfoPortal.Application.Exeptions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Security.Cryptography.X509Certificates;


namespace InfoPortal.Host.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(
            RequestDelegate next,
            ILogger<ErrorHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unhandled exception occurred.");
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            if (ex is NotFoundException)
            {
                var exeption = (NotFoundException)ex;
               
                await DataForExpectedExceptionAsync(context, (int)HttpStatusCode.NotFound, exeption);

            }
            else if (ex is ConflictExeption)
            {
                var exeption = (ConflictExeption)ex;

                await DataForExpectedExceptionAsync(context, (int)HttpStatusCode.Conflict, exeption);

            }
            else
            {
                await DataForNotExpectedExceptionAsync(context, (int)HttpStatusCode.InternalServerError, ex);
            }
        }

        private async Task DataForExpectedExceptionAsync(HttpContext context, int statusCode, BaseException ex)
        {
            var errorModel = new ErrorModel
            {
                ErrorMessage = ex.ErrorMessage,
                ErrorLog = ex.ErrorLog,
                StatusCode = statusCode
            };
            await WriteContext(context, errorModel, statusCode);
        }

        private async Task DataForNotExpectedExceptionAsync(HttpContext context, int statusCode, Exception ex)
        {
            var errorModel = new ErrorModel
            {
                ErrorMessage = "Внутренняя ошибка сервиса",
                ErrorLog = ex.StackTrace,
                StatusCode = statusCode
            };
            await WriteContext(context, errorModel, statusCode);
        }

        private async Task WriteContext(HttpContext context, ErrorModel errorModel, int statusCode)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;
            var errorJson = JsonConvert.SerializeObject(errorModel);
            await context.Response.WriteAsync(errorJson);
        }
    }

}

