namespace UniversityMVC.Repositories.Sql;

using Dapper;
using UniversityMVC.Models;
using UniversityMVC.Repositories.Base;
using Microsoft.Data.SqlClient;

public class DapperTeacherRepository : ITeacherRepository
{
    private readonly string ConnectionString;

    public DapperTeacherRepository(string connectionString)
    {
        this.ConnectionString = connectionString;
    }

    public List<Teacher> GetAllTeachers()
    {
        var connection = new SqlConnection(ConnectionString);

        connection.Open();
        
        var TeacherList = connection.Query<Teacher>(@"select * from Teachers)");

        connection.Close();

        return TeacherList.ToList();
    }

    public Teacher GetTeacherById(int id)
    {
        var connection = new SqlConnection(ConnectionString);

        connection.Open();

        var teacher = connection.QueryFirstOrDefault<Teacher>("select * from Teachers where Id = @id", id);

        connection.Close();

        return teacher;
    }

    public void AddTeacher(Teacher teacher)
    {
        var connection = new SqlConnection(ConnectionString);

        connection.Open();

        connection.Execute(@"insert into Teachers (Id, Name, Surname) 
        values (@Id, @Name, @Surname)", teacher);

        connection.Close();
    }

    public void UpdateTeacher(int id, string name, string surname)
    {
        var connection = new SqlConnection(ConnectionString);

        connection.Open();

        connection.Execute("update Teachers set Name = @Name, Surname = @Surname where Id = @Id", new{id, name, surname});

        connection.Close();

    }

    public void DeleteTeacher(int id)
    {
        var connection = new SqlConnection(ConnectionString);

        connection.Open();

        connection.Execute("delete Teachers where Id = @Id", id);

        connection.Close();
    }

}