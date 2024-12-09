using Infrastructure.Models;
using Npgsql;
using Dapper;
using Infrastructure.DataContext;

namespace Infrastructure.Service;
using Infrastructure.Interfaces;

public class StudentsService:IStudentsService
{
    private readonly DapperContext context;

    public StudentsService()
    {
        context = new DapperContext();
    }
    public bool DeleteStudent(int id)
    {
        try
        {
                string cmd = "Delete from Students where Id = @id";
                var result = context.Connection().Execute(cmd, new { Id = id });
                return result > 0;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public bool UpdateStudent(Students student)
    {
            string cmd =
                "update students set Student_Name = @Student_Name, Email = @Email,Group_Id = @Group_Id,Course_Id = @Course_Id";
            var result = context.Connection().Execute(cmd, student);
            return result > 0;
    }

    public bool InsertStudent(Students student)
    {
            string cmd =
                "Insert into Students (Student_Name, Email, Group_Id, Course_Id) values (Student_Name=@Student_Same, Email = @Email, Group_Id = @Group_Id,Course_Id = @Course_Id)";
            var result = context.Connection().Execute(cmd, student);
            return result > 0;
    }

    public List<Students> GetStudents()
    {
        try
        {
                string cmd = "select * from students";
                List<Students> result = context.Connection().Query<Students>(cmd).ToList();
                return result;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Students GetStudentById(int id)
    {
            string cmd = "select * from Students where Student_Id = @Student_Id";
            Students result = context.Connection().QuerySingleOrDefault<Students>(cmd, new { Id = id });
            return result;
    }
}