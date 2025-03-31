using UniversityMVC.Middlewares;
using UniversityMVC.Repositories;
using UniversityMVC.Repositories.Base;
using UniversityMVC.Services;
using UniversityMVC.Repositories.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IStudentRepository>(_ =>
    new JsonStudentRepository(@"/Users/ibrahimasgarov/Desktop/University/UniversityMVC/StudentsJsonFile.json"));

builder.Services.AddScoped<ITeacherRepository>(_ =>
    new JsonTeacherRepository(@"/Users/ibrahimasgarov/Desktop/University/UniversityMVC/TeachersJsonFile.json"));

builder.Services.AddScoped<IHttpLogRepository, HttpLogRepository>();
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
