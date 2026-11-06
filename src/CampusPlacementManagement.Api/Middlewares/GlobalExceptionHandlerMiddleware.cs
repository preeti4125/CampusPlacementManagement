using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace CampusPlacementManagement.Api.Middlewares;

public class GlobalExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;
    public GlobalExceptionHandlerMiddleware(RequestDelegate next) => _next = next;

    public async Task InvokeAsync(HttpContext context)
    {
        try { await _next(context); }
        catch (Exception ex)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/problem+json";
            var details = new ProblemDetails { Status = context.Response.StatusCode, Title = "An error occurred", Detail = ex.Message };
            await context.Response.WriteAsync(JsonSerializer.Serialize(details));
        }
    }
}
