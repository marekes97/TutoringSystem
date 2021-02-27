using System;
using System.Collections.Generic;
using System.Text;

namespace TutoringSystemLib.Entities
{
    public class Availability
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public List<Interval> Intervals { get; set; } 

        public int TutorId { get; set; }
        public virtual Tutor Tutor { get; set; }
    }
}
