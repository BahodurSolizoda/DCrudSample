using Infrastructure.Models;

namespace Infrastructure.Interfaces;


public interface ICoursesService
{
    bool DeleteCourse(int id);
    bool UpdateCourse(Courses user);
    bool InsertCourse(Courses user);
    List<Courses> GetCourses();
    Courses GetCourseById(int id);
}