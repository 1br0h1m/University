namespace UniversityMVC.Repositories.Base;

using UniversityMVC.Models;
public interface ITeacherRepository
{
    List<Teacher> GetAllTeachers();
    Teacher GetTeacherById(int id);
    void AddTeacher(Teacher teacher);
    void UpdateTeacher(int id, string name, string surname);

    void DeleteTeacher(int id);
}

