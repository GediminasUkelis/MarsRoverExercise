﻿using MarsRoverExercise.API.Infrastructure.Exceptions;
using MarsRoverExercise.Application.Exceptions;
using Newtonsoft.Json;
using System.Net;

namespace MarsRoverExercise.API.Infrastructure.Middleware
{
    public class ErrorHandling
    {
        private readonly RequestDelegate next;

        public ErrorHandling(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            object errors = null;
            switch (ex)
            {
                case InputValidationException inputValidationException:
                    errors = inputValidationException.Error;
                    context.Response.StatusCode = (int)inputValidationException.Code;
                    break;
                case InvalidMoveException InvalidMoveException:
                    errors = InvalidMoveException.Error;
                    context.Response.StatusCode = (int)InvalidMoveException.Code;
                    break;
                case Exception exception:
                    errors = string.IsNullOrWhiteSpace(exception.Message) ? "Error" : exception.Message;
                    context.Response.StatusCode = (int)HttpStatusCode.Conflict;
                    break;
            }

            context.Response.ContentType = "application/json";
            if (errors != null)
            {
                var result = JsonConvert.SerializeObject(
                    new { errors });
                await context.Response.WriteAsync(result);
            }
        }
    }
}
