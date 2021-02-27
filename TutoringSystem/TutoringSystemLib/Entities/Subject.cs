using System;
using System.Collections.Generic;
using System.Text;

namespace TutoringSystemLib.Entities
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual List<Reservation> Reservations { get; set; }

        public int TutorId { get; set; }
        public virtual Tutor Tutor { get; set; }
    }
}
