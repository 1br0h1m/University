using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using UniversityMVC.Models;
using UniversityMVC.Repositories.Json;

namespace UniversityMVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;



    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Student()
    {
        JsonStudentRepository repository = new JsonStudentRepository("StudentsJsonFile.json");
        List<Student> students = repository.GetAllStudents(); 
        return View(students);
    }

    public IActionResult Teacher()
    {
        JsonTeacherRepository repository = new JsonTeacherRepository("TeachersJsonFile.json");
        List<Teacher> teachers = repository.GetAllTeachers(); 
        return View(teachers);
    }

    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
