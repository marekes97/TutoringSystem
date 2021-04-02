using System.Collections.Generic;
using TutoringSystemLib.Entities;

namespace TutoringSystemAPI.Repositories
{
    public interface IIntervalRepository
    {
        ICollection<Interval> GetIntervals();
        ICollection<Interval> GetIntervals(Availability availability);
    }
}