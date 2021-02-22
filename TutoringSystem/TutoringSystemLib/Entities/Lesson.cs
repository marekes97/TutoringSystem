using System;
using System.Collections.Generic;
using System.Text;

namespace TutoringSystemLib.Entities
{
    public class Lesson
    {
        public int Id { get; set; }
        public Subject Subject { get; set; }
        public double Duration { get; set; }
        public string Description { get; set; }
    }
}
