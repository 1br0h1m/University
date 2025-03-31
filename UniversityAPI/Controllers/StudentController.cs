namespace UniversityAPI.Controllers;

using UniversityAPI.Models;
using Microsoft.AspNetCore.Mvc;

[Route("/[controller]")]
public class StudentController : ControllerBase
{
    

    [HttpGet("{id}")]
    public Student GetStudent(int id) {
        return new Student {
            Id = id,
            Name = "Bob",
            Surname = "Marley"
        };
    }
}