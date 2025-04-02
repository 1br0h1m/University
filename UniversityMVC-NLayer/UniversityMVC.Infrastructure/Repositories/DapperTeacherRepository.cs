using Dapper;
using Microsoft.Data.SqlClient;
using UniversityMVC.Models;
using UniversityMVC.Repositories.Base;

namespace UniversityMVC.Repositories.Sql;

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

        var teacherList = connection.Query<Teacher>("select * from teachers").ToList();

        connection.Close();
        return teacherList;
    }

    public Teacher GetTeacherById(int id)
    {
        var connection = new SqlConnection(ConnectionString);
        connection.Open();

        var teacher = connection.QueryFirstOrDefault<Teacher>(
            "select * from teachers where id = @id", new { id });

        connection.Close();
        return teacher;
    }

    public void AddTeacher(Teacher teacher)
    {
        var connection = new SqlConnection(ConnectionString);
        connection.Open();

        connection.Execute(@"
            insert into teachers (name, surname, email)
            values (@Name, @Surname, @Email)", teacher);

        connection.Close();
    }

    public void UpdateTeacher(int id, string name, string surname, string email)
    {
        var connection = new SqlConnection(ConnectionString);
        connection.Open();

        connection.Execute(@"
            update teachers 
            set name = @name, surname = @surname, email = @email 
            where id = @id", new { id, name, surname, email });

        connection.Close();
    }

    public void DeleteTeacher(int id)
    {
        var connection = new SqlConnection(ConnectionString);
        connection.Open();

        connection.Execute("delete from teachers where id = @id", new { id });

        connection.Close();
    }
}
