using System;
using System.Collections.Generic;
using System.Text;
using TutoringSystemLib.Entities;

namespace TutoringSystemLib.Models
{
    public class TutorReservationDetailsDto
    {
        public string StudentName { get; set; }
        public string Subject { get; set; }
        public DateTime StartTime { get; set; }
        public double Duration { get; set; }
        public string Description { get; set; }
        public Place Place { get; set; }
    }
}
