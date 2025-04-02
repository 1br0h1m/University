using UniversityMVC.Middlewares;
using UniversityMVC.Repositories;
using UniversityMVC.Repositories.Base;
using UniversityMVC.Services;
using UniversityMVC.Repositories.Json;
using UniversityMVC.Repositories.Sql;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();

// builder.Services.AddScoped<IStudentRepository>(_ =>
//     new JsonStudentRepository(@"/Users/ibrahimasgarov/Desktop/University/UniversityMVC/Database/StudentsJsonFile.json"));

// builder.Services.AddScoped<ITeacherRepository>(_ =>
//     new JsonTeacherRepository(@"/Users/ibrahimasgarov/Desktop/University/UniversityMVC/Database/TeachersJsonFile.json"));

var connectionString = "Server=localhost;Database=UniversityDataBase;User Id=admin;Password=admin;Encrypt=False;TrustServerCertificate=True;"
;

builder.Services.AddScoped<IStudentRepository>(_ =>
    new DapperStudentRepository(connectionString));

builder.Services.AddScoped<ITeacherRepository>(_ =>
    new DapperTeacherRepository(connectionString));

builder.Services.AddScoped<IHttpLogRepository>(_ =>
    new HttpLogRepository(connectionString));

builder.Services.AddScoped<IHttpLogger, HttpLogger>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseMiddleware<ExceptionMiddleware>();
app.UseMiddleware<LoggingMiddleware>();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
