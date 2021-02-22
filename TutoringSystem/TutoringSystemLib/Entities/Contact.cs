using System;
using System.Collections.Generic;
using System.Text;

namespace TutoringSystemLib.Entities
{
    public class Contact
    {
        public int Id { get; set; }
        public List<PhoneNumber> PhoneNumbers { get; set; }
        public string Email { get; set; }
        public string DiscordName { get; set; }
    }
}
