namespace UniversityMVC.Repositories.Base;

using UniversityMVC.Models;
public interface IStudentRepository
{
    List<Student> GetAllStudents();
    Student GetStudentById(int id);
    void AddStudent(Student student);
    void UpdateStudent(int id, string name, string surname);

    void DeleteStudent(int id);
}

