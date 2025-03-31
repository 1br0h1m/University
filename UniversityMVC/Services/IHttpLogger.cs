namespace UniversityMVC.Services;


public interface IHttpLogger
{
    Task LogAsync(HttpContext context, string? message = null);
}
