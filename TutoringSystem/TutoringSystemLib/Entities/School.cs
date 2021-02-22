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

        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
