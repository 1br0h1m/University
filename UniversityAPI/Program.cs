using UniversityAPI.Repositories.Base;
using UniversityAPI.Repositories.Json;
using UniversityAPI.Repositories.Sql;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddScoped<IStudentRepository>((serviceProvider) =>
{
    return new JsonStudentRepository("/Users/ibrahimasgarov/Desktop/University/UniversityAPI/StudentsJsonFile.json");
});

// builder.Services.AddScoped<IStudentRepository>((serviceProvider) =>
// {
//     return new DapperStudentRepository("Server=localhost;Database=StudentsDb2;User Id=SA;Password=MyPass@word;TrustServerCertificate=True;");
// });

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();