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
    public void AddTeacher(Teacher teacher)
{
    var teacherList = GetAllTeachers();

    int newId = 1;
    if (teacherList.Count > 0)
    {
        newId = teacherList.Max(s => s.Id) + 1;
    }

    teacher.Id = newId;
    teacherList.Add(teacher);
    File.WriteAllText(filePath, JsonSerializer.Serialize(teacherList));
}

    public void UpdateTeacher(int id, string name, string surname, string email)
    {

        var TeacherList = GetAllTeachers();
        var TeacherChange = TeacherList.FirstOrDefault(Teacher => Teacher.Id == id);

        TeacherChange.Name = name;
        TeacherChange.Surname = surname;
        TeacherChange.Email = email;

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
