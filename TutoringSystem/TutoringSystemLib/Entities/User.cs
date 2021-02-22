using System;
using System.Collections.Generic;
using System.Text;

namespace TutoringSystemLib.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Role Role { get; set; }
        public Contact Contact { get; set; }
        public School School { get; set; }
    }
}
