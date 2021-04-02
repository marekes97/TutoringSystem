using System.Collections.Generic;
using TutoringSystemLib.Entities;

namespace TutoringSystemAPI.Repositories
{
    public interface ISubjectRepository
    {
        Subject GetSubject(int id);
        Subject GetSubject(Reservation reservation);
        Subject GetSubject(string name);
        ICollection<Subject> GetSubjects();
    }
}