using System;
using System.Collections.Generic;
using System.Text;

namespace TutoringSystemLib.Models
{
    public class ReservationDto
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public double Duration { get; set; }
    }
}
