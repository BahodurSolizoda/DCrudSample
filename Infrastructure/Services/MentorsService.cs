using Dapper;
using Infrastructure.DataContext;
using Infrastructure.Models;
using Npgsql;

namespace Infrastructure.Service;
using Infrastructure.Interfaces;

public class MentorsService :IMentorsService
{
    private readonly DapperContext context;

    public MentorsService()
    {
        context = new DapperContext();
    }
    public bool DeleteMentor(int id)
    {
        try
        {
                string cmd = "Delete from Mentors where Id = @Id";
                var result = context.Connection().Execute(cmd, new { Id = id });
                return result > 0;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public bool UpdateMentor(Mentors mentor)
    {
        try
        {
                string cmd = "Update Mentors set Mentor_Name = @Mentor_Name,Email = @Email,Course_Id = @Course_Id where Id = @id";
                var result = context.Connection().Execute(cmd, mentor);
                return result > 0;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public bool InsertMentor(Mentors mentor)
    {
        try
        {
                string cmd =
                    "Insert into Mentors(Mentor_Name,Email,Course_Id) values (Mentor_Name = @Mentor_Name,Email = @Email,Course_Id = @Course_Id)";
                var result = context.Connection().Execute(cmd, mentor);
                return result > 0;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public List<Mentors> GetMentors()
    {
        try
        {
                string cmd = "SELECT * FROM Mentors";
                List<Mentors> result = context.Connection().Query<Mentors>(cmd).ToList();
                return result;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Mentors GetMentorById(int id)
    {
        try
        {
                string cmd = "select * from Mentors where Mentor_Id = @Mentor_Id";
                Mentors result = context.Connection().QueryFirstOrDefault<Mentors>(cmd, new { Id = id });
                return result;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}