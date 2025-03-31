namespace UniversityMVC.Repositories.Json;

using UniversityMVC.Repositories.Base;
using System.Text.Json;
using UniversityMVC.Models;

public class JsonStudentRepository : IStudentRepository
{
    string filePath = "StudentsJsonFile.json";

    public JsonStudentRepository(string filePath)
    {
        this.filePath = filePath;
    }

    public List<Student> GetAllStudents()
    {
        var studentsJson = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<List<Student>>(studentsJson);
    }

    public Student GetStudentById(int id)
    {
        var studentList = GetAllStudents();
        return studentList.FirstOrDefault(student => student.Id == id);
    }
    public void AddStudent(Student student)
    {
        var studentList = GetAllStudents();
        studentList.Add(student);
        File.WriteAllText(filePath, JsonSerializer.Serialize(studentList));
    }

    public void UpdateStudent(int id, string name, string surname)
    {

        var studentList = GetAllStudents();
        var studentChange = studentList.FirstOrDefault(student => student.Id == id);

        studentChange.Name = name;
        studentChange.Surname = surname;

        File.WriteAllText(filePath, JsonSerializer.Serialize(studentList));
    }

    public void DeleteStudent(int id)
    {
        var studentList = GetAllStudents();
        var studentDelete = studentList.FirstOrDefault(student => student.Id == id);

        studentList.Remove(studentDelete);

        File.WriteAllText(filePath, JsonSerializer.Serialize(studentList));
    }
}
