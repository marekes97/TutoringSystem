using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TutoringSystemLib.Entities;

namespace TutoringSystemAPI.Repositories
{
    public class IntervalRepository : IIntervalRepository
    {
        public readonly AppDbContext dbContext;

        public IntervalRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public ICollection<Interval> GetIntervals() => dbContext.Intervals
            .Include(i => i.Availability)
            .ToList();

        public ICollection<Interval> GetIntervals(Availability availability) => GetIntervals()
            .Where(i => i.Availability.Equals(availability))
            .ToList();
    }
}
