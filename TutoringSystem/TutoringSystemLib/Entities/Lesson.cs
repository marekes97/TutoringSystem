using System;
using System.Collections.Generic;
using System.Text;

namespace TutoringSystemLib.Entities
{
    public class Lesson
    {
        public int Id { get; set; }
        public double Duration { get; set; }
        public string Description { get; set; }

        public virtual Subject Subject { get; set; }

        public int ReservationId { get; set; }
        public virtual Reservation Reservation { get; set; }
    }
}
