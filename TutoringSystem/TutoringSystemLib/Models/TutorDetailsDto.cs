using System;
using System.Collections.Generic;
using System.Text;

namespace TutoringSystemLib.Models
{
    public class TutorDetailsDto
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ContactDto Contact { get; set; }
        public AddressDto Address { get; set; }
    }
}
