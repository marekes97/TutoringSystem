﻿using System;
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

        public int SubjectId { get; set; }
        public virtual Subject Subject { get; set; }

        public int TutorId { get; set; }
        public virtual Tutor Tutor { get; set; }

        public int StudentId { get; set; }
        public virtual Student Student { get; set; }
    }
}
