namespace UniversityAPI.Repositories.Base;

using UniversityAPI.Models;
public interface IStudentRepository
{
    List<Student> GetAllStudents();
    Student GetStudentById(int id);
    void AddStudent(Student student);
    void UpdateStudent(int id, string name, string surname);

    void DeleteStudent(int id);
}

