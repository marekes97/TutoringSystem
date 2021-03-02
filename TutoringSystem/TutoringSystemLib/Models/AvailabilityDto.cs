using System;
using System.Collections.Generic;
using System.Text;

namespace TutoringSystemLib.Models
{
    public class AvailabilityDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public List<IntervalDto> Intervals { get; set; }
    }
}
