namespace UniversityAPI.Controllers;

using UniversityAPI.Repositories.Json;
using UniversityAPI.Repositories.Sql;
using UniversityAPI.Models;
using Microsoft.AspNetCore.Mvc;
using UniversityAPI.Repositories.Base;

[ApiController]
[Route("api/[controller]")]
public class StudentController : ControllerBase
{
    private readonly IStudentRepository studentRepository;

    
    public StudentController(IStudentRepository studentRepository)
    {
        this.studentRepository = studentRepository;
    }
    
    [HttpGet]
    public IActionResult GetAllStudents()
    {
        var students = studentRepository.GetAllStudents();
        return Ok(students);
    }

    [HttpGet("{id}")]
    public IActionResult GetStudentById(int id)
    {
        var student = studentRepository.GetStudentById(id);

        return Ok(student);
    }

    [HttpPost]
    public IActionResult AddStudent([FromBody] Student student)
    {
        studentRepository.AddStudent(student);
        return CreatedAtAction(nameof(GetStudentById), new { id = student.Id }, student);
    }

    [HttpPut]
    public IActionResult UpdateStudent(int id, string name, string surname)
    {
        studentRepository.UpdateStudent(id, name, surname);
        return Ok();
    }
    
    [HttpDelete("{id}")]
    public IActionResult DeleteStudent(int id)
    {
        studentRepository.DeleteStudent(id);
        return Ok();
    }
}