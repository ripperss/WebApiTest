namespace Notes.WebApi.Middleware;

public static  class CustomExeptionMiddlewareExtension
{
    public static IApplicationBuilder UseCustomExeptionHandler(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<CustomExeptionMiddleware>();
    }
    

    
}
