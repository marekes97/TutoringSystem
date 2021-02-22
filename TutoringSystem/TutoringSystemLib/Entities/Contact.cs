using System;
using System.Collections.Generic;
using System.Text;

namespace TutoringSystemLib.Entities
{
    public class Contact
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string DiscordName { get; set; }

        public virtual List<PhoneNumber> PhoneNumbers { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
