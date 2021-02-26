using System;
using System.Collections.Generic;
using System.Text;
using TutoringSystemLib.Entities;

namespace TutoringSystemLib.Models
{
    public class StudentDetailsDto
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ContactDto Contact { get; set; }
        public SchoolDto School { get; set; }
        public AddressDto Address { get; set; }
    }
}
