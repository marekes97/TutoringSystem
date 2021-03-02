using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public ICollection<Lesson> GetLessons() => dbContext.Lessons.ToList();

        public Lesson GetLesson(int id) => dbContext.Lessons.FirstOrDefault(l => l.Id.Equals(id));

        public Lesson GetLesson(Reservation reservation) => dbContext.Lessons.FirstOrDefault(l => l.Reservation.Equals(reservation));
    }
}
