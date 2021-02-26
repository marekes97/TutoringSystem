using System;
using System.Collections.Generic;
using System.Text;
using TutoringSystemLib.Entities;

namespace TutoringSystemLib.Models
{
    public class SchoolDto
    {
        public string SchoolName { get; set; }
        public EducationLevel EducationLevel { get; set; }
        public int EducationYear { get; set; }
    }
}
