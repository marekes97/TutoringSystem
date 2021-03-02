using System.Collections.Generic;
using TutoringSystemLib.Entities;

namespace TutoringSystemAPI.Repositories
{
    public interface ILessonRepository
    {
        Lesson GetLesson(int id);
        Lesson GetLesson(Reservation reservation);
        ICollection<Lesson> GetLessons();
    }
}