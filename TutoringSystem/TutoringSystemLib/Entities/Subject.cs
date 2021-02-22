using System;
using System.Collections.Generic;
using System.Text;

namespace TutoringSystemLib.Entities
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal HourlRate  { get; set; }

        public int LessonId { get; set; }
        public virtual Lesson Lesson { get; set; }
    }
}
