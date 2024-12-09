using Infrastructure.Models;

namespace Infrastructure.Interfaces;

public interface IStudentsService
{
    bool DeleteStudent(int id);
    bool UpdateStudent(Students user);
    bool InsertStudent(Students user);
    List<Students> GetStudents();
    Students GetStudentById(int id);
}