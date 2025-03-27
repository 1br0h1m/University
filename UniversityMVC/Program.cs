using UniversityMVC.Repositories.Base;
using UniversityMVC.Repositories.Json;
using UniversityMVC.Repositories.Sql;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();


builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IStudentRepository>(provider => new JsonStudentRepository(@"/Users/ibrahimasgarov/Desktop/University/UniversityMVC/StudentsJsonFile.json"));

builder.Services.AddScoped<ITeacherRepository>(provider => new JsonTeacherRepository(@"/Users/ibrahimasgarov/Desktop/University/UniversityMVC/TeachersJsonFile.json"));


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
