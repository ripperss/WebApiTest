using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Filters;
using System.ComponentModel.DataAnnotations;
using System.Net;
using Notes.Application.Common.Exeptions;

namespace Notes.WebApi.Middleware;

public class CustomExeptionMiddleware
{
    private RequestDelegate next ;

    public CustomExeptionMiddleware(RequestDelegate requestDelegate)
    {
        next = requestDelegate;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await next.Invoke(context);
        }
        catch (Exception ex)
        {
            await HandleExeptionAsync(context, ex);
        }

    }
    private Task HandleExeptionAsync(HttpContext context, Exception ex)
    {
        var code = HttpStatusCode.InternalServerError;
        var result = string.Empty;
        switch(ex)
        {
            case ValidationException validationException:
                code = HttpStatusCode.BadRequest;
                result = JsonSerializer.Serialize(code);
                break;
            case NotFoundExeptions:
                code = HttpStatusCode.NotFound;
                break;  
        }
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)code;
        if (result == null)
        {
            result = JsonSerializer.Serialize(new {arror  = ex.Message});
        }
        return context.Response.WriteAsync(result);
    }
}
