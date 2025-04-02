using Dapper;
using Microsoft.Data.SqlClient;
using UniversityMVC.Models;
using UniversityMVC.Repositories.Base;

namespace UniversityMVC.Repositories.Sql;

public class DapperStudentRepository : IStudentRepository
{
    private readonly string ConnectionString;

    public DapperStudentRepository(string connectionString)
    {
        this.ConnectionString = connectionString;
    }

    public List<Student> GetAllStudents()
    {
        var connection = new SqlConnection(ConnectionString);
        connection.Open();

        var studentList = connection.Query<Student>("select * from students").ToList();

        connection.Close();
        return studentList;
    }

    public Student GetStudentById(int id)
    {
        var connection = new SqlConnection(ConnectionString);
        connection.Open();

        var student = connection.QueryFirstOrDefault<Student>(
            "select * from students where id = @id", new { id });

        connection.Close();
        return student;
    }

    public void AddStudent(Student student)
    {
        var connection = new SqlConnection(ConnectionString);
        connection.Open();

        connection.Execute(@"
            insert into students (name, surname, grade, email)
            values (@Name, @Surname, @Grade, @Email)", student);

        connection.Close();
    }

    public void UpdateStudent(int id, string name, string surname, int grade, string email)
    {
        var connection = new SqlConnection(ConnectionString);
        connection.Open();

        connection.Execute(@"
            update students 
            set name = @name, surname = @surname, grade = @grade, email = @email 
            where id = @id", new { id, name, surname, grade, email });

        connection.Close();
    }

    public void DeleteStudent(int id)
    {
        var connection = new SqlConnection(ConnectionString);
        connection.Open();

        connection.Execute("delete from students where id = @id", new { id });

        connection.Close();
    }
}
