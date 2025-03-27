namespace UniversityMVC.Models;

public class Student
{
    public int Id { get; set; }
    public required string Name { get; set; } 
    public required string Surname { get; set; }

    public Student() {}

    public Student(int id, string name, string surname)
    {
        Id = id;
        Name = name;
        Surname = surname;
    }
}
