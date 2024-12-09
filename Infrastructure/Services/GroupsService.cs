using Dapper;
using Infrastructure.DataContext;
using Infrastructure.Models;
using Npgsql;

namespace Infrastructure.Service;
using Infrastructure.Interfaces;

public class GroupsService : IGroupsService
{
    private readonly DapperContext context;

    public GroupsService()
    {
        context = new DapperContext();
    }
    
    public bool DeleteGroup(int id)
    {
        try
        {
                var cmd = "Delete from Groups where id = @id";
                var result = context.Connection().Execute(cmd, new { Id = @id });
                return result > 0;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public bool UpdateGroup(Groups group)
    {
        try
        {
                var cmd = "UPDATE Groups SET group_name = @group_name WHERE Id = @Id";
                var result = context.Connection().Execute(cmd, group);
                return result > 0;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public bool InsertGroup(Groups group)
    {
        try
        {
                var cmd = "INSERT INTO Groups (Group_Id,Group_Name, Course_Id) VALUES (@Group_Id,@Group_Name, @Course_Id)";
                var result = context.Connection().Execute(cmd, group);
                return result > 0;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public List<Groups> Groups()
    {
        try
        {
                var cmd = "Select * from Groups";
                List<Groups> groups = context.Connection().Query<Groups>(cmd).ToList();
                return groups;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Groups GetGroupById(int id)
    {
        try
        {
                string cmd = "SELECT * FROM Groups WHERE Id = @id";
                Groups groups = context.Connection().QuerySingleOrDefault<Groups>(cmd, new { Id = @id });
                return groups;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}