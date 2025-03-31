namespace UniversityMVC.Models;

public class Teacher
{
    public int Id { get; set; }
    public required string Name { get; set; } 
    public required string Surname { get; set; }

    public Teacher() {}

    public Teacher(int id, string name, string surname)
    {
        Id = id;
        Name = name;
        Surname = surname;
    }
}
