namespace UniversityMVC.Repositories;

using UniversityMVC.Models;

public interface IHttpLogRepository
{
    Task InsertAsync(HttpLog log);
}
