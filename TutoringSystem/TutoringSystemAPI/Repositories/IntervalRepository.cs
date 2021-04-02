using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public ICollection<Interval> GetIntervals() => dbContext.Intervals.ToList();
        public ICollection<Interval> GetIntervals(Availability availability) => dbContext.Intervals
            .Where(i => i.Availability.Equals(availability)).ToList();
    }
}
