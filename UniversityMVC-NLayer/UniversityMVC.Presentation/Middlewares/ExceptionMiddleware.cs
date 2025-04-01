using System.Net;
using UniversityMVC.Responses;

namespace UniversityMVC.Middlewares;

public class ExceptionMiddleware
{
    private readonly RequestDelegate next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        this.next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await this.next(context);
        }
        catch (ArgumentNullException ex)
        {
            if (!context.Response.HasStarted)
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                await context.Response.WriteAsJsonAsync(new BadRequestResponse(ex.Message)
                {
                    Parameter = ex.ParamName
                });
            }

            context.Items["exception"] = ex.ToString();
        }
        catch (KeyNotFoundException ex)
        {
            if (!context.Response.HasStarted)
            {
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                await context.Response.WriteAsJsonAsync(new NotFoundResponse(ex.Message));
            }

            context.Items["exception"] = ex.ToString();
        }
        catch (Exception ex)
        {
            if (!context.Response.HasStarted)
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await context.Response.WriteAsJsonAsync(new InternalServerErrorResponse("Internal server error"));
            }

            context.Items["exception"] = ex.ToString();
        }
    }
}
