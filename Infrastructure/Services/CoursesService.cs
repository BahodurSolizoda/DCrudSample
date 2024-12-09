using Dapper;
using Infrastructure.Interfaces;
using Infrastructure.Models;
using Infrastructure.DataContext;
using Npgsql;

namespace Infrastructure.Service;

public class CoursesService :ICoursesService
{
    private readonly DapperContext context;

    public CoursesService()
    {
        context = new DapperContext();
    }
    public bool DeleteCourse(int id)
    {
        try
        {
                string cmd = "Delete from Corses where id = @id";
                var affected = context.Connection().Execute(cmd,new {Id = id});
                return affected > 0;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public bool UpdateCourse(Courses course)
    {
        try
        {
                string cmd = "Update Courses set Course_Name = @Course_Name, Description = @Description where id = @id";
                var affected = context.Connection().Execute(cmd, course);
                return affected > 0;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public bool InsertCourse(Courses course)
    {
        try
        {
                string cmd = "Insert into Courses(Course_id,Course_name,Description) values (@Id,@Name,@Description) ";
                var affected = context.Connection().Execute(cmd, course);
                return affected > 0;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public List<Courses> GetCourses()
    {
        try
        {
                string cmd = "Select * from Courses";
                List<Courses> courses = context.Connection().Query<Courses>(cmd).ToList();
                return courses;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Courses GetCourseById(int id)
    {
        try
        {
                string cmd = "Select * from Courses where id = @id";
                Courses courses = context.Connection().QuerySingleOrDefault<Courses>(cmd, new { Id = @id });
                return courses;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}