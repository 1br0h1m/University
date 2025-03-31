using System.Text.Json;
using UniversityMVC.Models;
using UniversityMVC.Repositories;
using Microsoft.AspNetCore.Http;

namespace UniversityMVC.Services;

public class HttpLogger : IHttpLogger
{
    private readonly IHttpLogRepository repository;

    public HttpLogger(IHttpLogRepository repository)
    {
        this.repository = repository;
    }

    public async Task LogAsync(HttpContext context, string? message = null)
    {
        context.Request.EnableBuffering();
        var reader = new StreamReader(context.Request.Body);
        var requestBody = await reader.ReadToEndAsync();
        context.Request.Body.Position = 0;

        var log = new HttpLog
        {
            RequestId = context.TraceIdentifier,
            Url = context.Request.Path,
            RequestBody = requestBody,
            RequestHeaders = JsonSerializer.Serialize(context.Request.Headers.ToDictionary(h => h.Key, h => h.Value.ToString())),
            MethodTypeId = 1,
            ResponseBody = message ?? "",
            ResponseHeaders = JsonSerializer.Serialize(context.Response.Headers.ToDictionary(h => h.Key, h => h.Value.ToString())),
            StatusCode = context.Response.StatusCode,
            CreationDateTime = DateTime.UtcNow,
            EndDateTime = DateTime.UtcNow,
            ClientIp = context.Connection.RemoteIpAddress?.ToString()
        };

        await repository.InsertAsync(log);
    }
}
