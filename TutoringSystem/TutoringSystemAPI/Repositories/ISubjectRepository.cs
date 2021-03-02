using System.Collections.Generic;
using TutoringSystemLib.Entities;

namespace TutoringSystemAPI.Repositories
{
    public interface ISubjectRepository
    {
        Subject GetSubject(int id);
        Subject GetSubject(Reservation reservation);
        ICollection<Subject> GetSubjects();
    }
}