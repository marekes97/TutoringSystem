using System;
using System.Collections.Generic;
using System.Text;

namespace TutoringSystemLib.Entities
{
    public class Reservation
    {
        public int Id { get; set; }
        public double Cost { get; set; }
        public DateTime StartTime { get; set; }

        public virtual Lesson Lesson { get; set; }
        public virtual Place Place { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
