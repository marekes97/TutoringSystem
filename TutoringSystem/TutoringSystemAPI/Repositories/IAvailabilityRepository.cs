using System.Collections.Generic;
using TutoringSystemLib.Entities;

namespace TutoringSystemAPI.Repositories
{
    public interface IAvailabilityRepository
    {
        void AddAvailability(Availability availability);
        void DeleteAvailability(int id);
        ICollection<Availability> GetAvailabilities(string userName);
        void UpdateAvailability(int id, Availability newAvailability);
    }
}