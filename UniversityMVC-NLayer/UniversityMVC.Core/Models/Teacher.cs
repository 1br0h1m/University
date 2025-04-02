using System.ComponentModel.DataAnnotations;

namespace UniversityMVC.Models;

public class Teacher
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required")]
    public required string Name { get; set; }

    [Required(ErrorMessage = "Surname is required")] 
    public required string Surname { get; set; }

    [EmailAddress(ErrorMessage = "Invalid email format")]
    public string Email { get; set; }

    public Teacher() {}

    public Teacher(int id, string name, string surname, string email)
    {
        Id = id;
        Name = name;
        Surname = surname;
        Email = email;
    }
}
