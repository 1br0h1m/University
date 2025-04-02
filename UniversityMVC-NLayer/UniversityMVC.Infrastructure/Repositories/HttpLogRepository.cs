namespace UniversityMVC.Repositories;

using Dapper;
using Microsoft.Data.SqlClient;
using UniversityMVC.Models;

public class HttpLogRepository : IHttpLogRepository
{
    private readonly string connectionString;

    public HttpLogRepository(string connectionString)
    {
        this.connectionString = connectionString;
    }

    public async Task InsertAsync(HttpLog log)
    {
        using var connection = new SqlConnection(this.connectionString);
        await connection.OpenAsync();

        await connection.ExecuteAsync(
            @"insert into HttpLogs (
                RequestId, Url, RequestBody, RequestHeaders, MethodTypeId,
                ResponseBody, ResponseHeaders, StatusCode,
                CreationDateTime, EndDateTime, ClientIp
              )
              values (
                @RequestId, @Url, @RequestBody, @RequestHeaders, @MethodTypeId,
                @ResponseBody, @ResponseHeaders, @StatusCode,
                @CreationDateTime, @EndDateTime, @ClientIp
              );",
            log);
    }
}
