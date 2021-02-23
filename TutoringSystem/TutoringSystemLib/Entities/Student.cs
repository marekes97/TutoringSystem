using System;
using System.Collections.Generic;
using System.Text;

namespace TutoringSystemLib.Entities
{
    public class Student : User
    {
        public virtual School School { get; set; }
        public virtual List<Reservation> Reservations { get; set; }
    }
}
