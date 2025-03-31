namespace UniversityMVC.Repositories;

using Dapper;
using Microsoft.Data.SqlClient;
using UniversityMVC.Models;


public class HttpLogRepository : IHttpLogRepository
{
    private readonly string connectionString;

    public HttpLogRepository(IConfiguration configuration)
    {
        this.connectionString = configuration.GetConnectionString("ConnectionString");
    }

    public async Task InsertAsync(HttpLog log)
    {
        using var connection = new SqlConnection(this.connectionString);
        await connection.OpenAsync();

        await connection.ExecuteAsync(
            @"INSERT INTO HttpLogs (
                RequestId, Url, RequestBody, RequestHeaders, MethodTypeId,
                ResponseBody, ResponseHeaders, StatusCode,
                CreationDateTime, EndDateTime, ClientIp
              )
              VALUES (
                @RequestId, @Url, @RequestBody, @RequestHeaders, @MethodTypeId,
                @ResponseBody, @ResponseHeaders, @StatusCode,
                @CreationDateTime, @EndDateTime, @ClientIp
              );",
            log);
    }
}
