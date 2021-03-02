using System;
using System.Collections.Generic;
using System.Text;
using TutoringSystemLib.Entities;

namespace TutoringSystemLib.Models
{
    public class StudentReservationDetailsDto
    {
        public string Subject { get; set; }
        public double Cost { get; set; }
        public DateTime StartTime { get; set; }
        public double Duration { get; set; }
        public string Description { get; set; }
        public Place Place { get; set; }
    }
}
