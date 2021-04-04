using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutoringSystemLib.Entities;

namespace TutoringSystemAPI.Repositories
{
    public class AvailabilityRepository : IAvailabilityRepository
    {
        public readonly AppDbContext dbContext;
        public readonly ITutorRepository tutorRepo;
        public readonly IIntervalRepository intervalRepo;

        public AvailabilityRepository(AppDbContext dbContext, ITutorRepository tutorRepo, IIntervalRepository intervalRepo)
        {
            this.dbContext = dbContext;
            this.tutorRepo = tutorRepo;
            this.intervalRepo = intervalRepo;
        }

        public ICollection<Availability> GetAvailabilities(string userName)
        {
            var user = tutorRepo.GetTutor(userName);
            var availabilities = dbContext.Availabilities
                .Include(a => a.Intervals)
                .Where(a => a.Tutor.Equals(user)).ToList();
            return availabilities;
        }

        public void AddAvailability(Availability availability)
        {
            dbContext.Availabilities.Add(availability);
            dbContext.SaveChanges();
        }

        public void UpdateAvailability(int id, Availability newAvailability)
        {
            var availability = dbContext.Availabilities.FirstOrDefault(a => a.Id.Equals(id));

            availability.Date = newAvailability.Date;
            availability.Intervals.Clear();
            foreach (var interval in newAvailability.Intervals)
                availability.Intervals.Add(interval);

            dbContext.Availabilities.Update(availability);
            dbContext.SaveChanges();
        }

        public void DeleteAvailability(int id)
        {
            var availability = dbContext.Availabilities.FirstOrDefault(a => a.Id.Equals(id));
            dbContext.Availabilities.Remove(availability);
            dbContext.SaveChanges();
        }
    }
}
