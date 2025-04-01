using System.ComponentModel.DataAnnotations;

namespace UniversityMVC.Models;

public class Student
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required")]

    public required string Name { get; set; } 

    [Required(ErrorMessage = "Surname is required")]

    public required string Surname { get; set; }

    [Range(0, 100, ErrorMessage = "Grade must be between 0 and 100")]
    public int Grade { get; set; }

    [EmailAddress(ErrorMessage = "Invalid email format")]
    public required string Email { get; set; }

    public Student() {}

    public Student(int id, string name, string surname, int grade, string email)
    {
        Id = id;
        Name = name;
        Surname = surname;
        Grade = grade;
        Email = email;
    }
}
