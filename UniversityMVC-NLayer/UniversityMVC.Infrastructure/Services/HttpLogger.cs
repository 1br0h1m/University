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

        string requestBody = "";
        using (var reader = new StreamReader(context.Request.Body, leaveOpen: true))
        {
            requestBody = await reader.ReadToEndAsync();
            context.Request.Body.Position = 0;
        }

        var log = new HttpLog
        {
            RequestId = context.TraceIdentifier,
            Url = context.Request.Path,
            RequestBody = requestBody,
            RequestHeaders = JsonSerializer.Serialize(context.Request.Headers.ToDictionary(h => h.Key, h => h.Value.ToString())),
            MethodTypeId = context.Request.Method switch
            {
                "GET" => 1,
                "POST" => 2,
                "PUT" => 3,
                "DELETE" => 4,
                _ => 0
            },
            ResponseBody = message ?? "",
            ResponseHeaders = JsonSerializer.Serialize(context.Response.Headers.ToDictionary(h => h.Key, h => h.Value.ToString())),
            StatusCode = context.Response.StatusCode,
            CreationDateTime = DateTime.UtcNow,
            EndDateTime = DateTime.UtcNow,
            ClientIp = context.Connection.RemoteIpAddress?.ToString() ?? "unknown"
        };
        Console.WriteLine($"[LOG] {log.RequestId} | {log.Url} | {log.MethodTypeId} | {log.StatusCode}");
        try
{
    await repository.InsertAsync(log);
}
catch (Exception ex)
{
    Console.WriteLine("[SQL LOGGING ERROR]");
    Console.WriteLine(ex.Message);
    Console.WriteLine(ex.StackTrace);
}

    }
}
