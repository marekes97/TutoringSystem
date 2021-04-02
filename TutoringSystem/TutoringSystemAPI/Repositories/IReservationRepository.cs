using System.Collections.Generic;
using TutoringSystemLib.Entities;

namespace TutoringSystemAPI.Repositories
{
    public interface IReservationRepository
    {
        ICollection<Reservation> GetStudentReservations(string userName);
        ICollection<Reservation> GetTutorReservations(string userName);
        Reservation GetStudentReservation(int id, string userName);
        Reservation GetTutorReservation(int id, string userName);
        void AddTutorReservation(Reservation reservation, string studentName);
    }
}