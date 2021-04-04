using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TutoringSystemLib.Entities;

namespace TutoringSystemAPI.Repositories
{
    public class LessonRepository : ILessonRepository
    {
        private readonly AppDbContext dbContext;

        public LessonRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public ICollection<Lesson> GetLessons() => dbContext.Lessons
            .Include(l => l.Reservation)
            .ToList();

        public Lesson GetLesson(int id) => GetLessons()
            .FirstOrDefault(l => l.Id.Equals(id));

        public Lesson GetLesson(Reservation reservation) => GetLessons()
            .FirstOrDefault(l => l.Reservation.Equals(reservation));
    }
}
