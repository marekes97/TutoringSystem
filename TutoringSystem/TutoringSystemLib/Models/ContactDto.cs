using System;
using System.Collections.Generic;
using System.Text;

namespace TutoringSystemLib.Models
{
    public class ContactDto
    {
        public string Email { get; set; }
        public string DiscordName { get; set; }
        public List<PhoneNumberDto> PhoneNumbers { get; set; }
    }
}
