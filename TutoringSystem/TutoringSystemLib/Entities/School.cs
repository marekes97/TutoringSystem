using System;
using System.Collections.Generic;
using System.Text;

namespace TutoringSystemLib.Entities
{
    public class School
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public EducationLevel EducationLevel { get; set; }
        public int Year { get; set; }

        public int StudentId { get; set; }
        public virtual Student Student { get; set; }
    }
}
