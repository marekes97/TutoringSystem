using System;
using System.Collections.Generic;
using System.Text;

namespace TutoringSystemLib.Entities
{
    public class AdditionalOrder
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Deadline { get; set; }
        public string Description { get; set; }
    }
}
