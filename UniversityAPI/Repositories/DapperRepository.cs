namespace UniversityAPI.Repositories.Sql;

using Dapper;
using UniversityAPI.Models;
using UniversityAPI.Repositories.Base;
using Microsoft.Data.SqlClient;

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
        
        var studentList = connection.Query<Student>(@"select * from Students)");

        connection.Close();

        return studentList.ToList();
    }

    public Student GetStudentById(int id)
    {
        var connection = new SqlConnection(ConnectionString);

        connection.Open();

        var student = connection.QueryFirstOrDefault<Student>("select * from Students where Id = @id", id);

        connection.Close();

        return student;
    }

    public void AddStudent(Student student)
    {
        var connection = new SqlConnection(ConnectionString);

        connection.Open();

        connection.Execute(@"insert into Students (Id, Name, Surname) 
        values (@Id, @Name, @Surname)", student);

        connection.Close();
    }

    public void UpdateStudent(int id, string name, string surname)
    {
        var connection = new SqlConnection(ConnectionString);

        connection.Open();

        connection.Execute("update Students set Name = @Name, Surname = @Surname where Id = @Id", new{id, name, surname});

        connection.Close();

    }

    public void DeleteStudent(int id)
    {
        var connection = new SqlConnection(ConnectionString);

        connection.Open();

        connection.Execute("delete Students where Id = @Id", id);

        connection.Close();
    }

}