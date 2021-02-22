using System;
using System.Collections.Generic;
using System.Text;

namespace TutoringSystemLib.Entities
{
    public class UsersAttribute
    {
        public int Id { get; set; }

        public int ReservationId { get; set; }
        public virtual Reservation Reservation { get; set; }

        public int TutorId { get; set; }
        public virtual User Tutor { get; set; }

        public int StudentId { get; set; }
        public virtual User Student { get; set; }
    }
}
