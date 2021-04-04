using System.Collections.Generic;
using TutoringSystemLib.Entities;

namespace TutoringSystemAPI.Repositories
{
    public interface ITutorRepository
    {
        void CreateTutor(Tutor tutor);
        void ChangePassword(string userName, string password);
        void DeleteTutor(string userName);
        Tutor GetTutor(string userName);
        Tutor GetTutor(Reservation reservation);
        ICollection<Tutor> GetTutors();
        void UpdateTutor(string userName, Tutor newTutor);
    }
}