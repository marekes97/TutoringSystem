using System;
using System.Collections.Generic;
using System.Text;

namespace TutoringSystemLib.Models
{
    public class OrderDetailsDto
    {
        public string Name { get; set; }
        public DateTime Deadline { get; set; }
        public string Description { get; set; }
        public double Cost { get; set; }
    }
}
