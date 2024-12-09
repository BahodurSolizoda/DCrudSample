using Infrastructure.Models;

namespace Infrastructure.Interfaces;

public interface IMentorsService
{
    bool DeleteMentor(int id);
    bool UpdateMentor(Mentors user);
    bool InsertMentor(Mentors user);
    List<Mentors> GetMentors();
    Mentors GetMentorById(int id);
}