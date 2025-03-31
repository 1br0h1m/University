namespace UniversityMVC.Repositories.Json;

using UniversityMVC.Repositories.Base;
using System.Text.Json;
using UniversityMVC.Models;

public class JsonTeacherRepository : ITeacherRepository
{
    string filePath = "TeachersJsonFile.json";

    public JsonTeacherRepository(string filePath)
    {
        this.filePath = filePath;
    }

    public List<Teacher> GetAllTeachers()
    {
        var TeachersJson = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<List<Teacher>>(TeachersJson);
    }

    public Teacher GetTeacherById(int id)
    {
        var TeacherList = GetAllTeachers();
        return TeacherList.FirstOrDefault(Teacher => Teacher.Id == id);
    }
    public void AddTeacher(Teacher Teacher)
    {
        var TeacherList = GetAllTeachers();
        TeacherList.Add(Teacher);
        File.WriteAllText(filePath, JsonSerializer.Serialize(TeacherList));
    }

    public void UpdateTeacher(int id, string name, string surname)
    {

        var TeacherList = GetAllTeachers();
        var TeacherChange = TeacherList.FirstOrDefault(Teacher => Teacher.Id == id);

        TeacherChange.Name = name;
        TeacherChange.Surname = surname;

        File.WriteAllText(filePath, JsonSerializer.Serialize(TeacherList));
    }

    public void DeleteTeacher(int id)
    {
        var TeacherList = GetAllTeachers();
        var TeacherDelete = TeacherList.FirstOrDefault(Teacher => Teacher.Id == id);

        TeacherList.Remove(TeacherDelete);

        File.WriteAllText(filePath, JsonSerializer.Serialize(TeacherList));
    }
}
