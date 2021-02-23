using System;
using System.Collections.Generic;
using System.Text;
using TutoringSystemLib.Entities;

namespace TutoringSystemLib.Models
{
    public class RegisterUserDto
    {
        public string Login { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string ConfirmPassword { get; set; }

        public string Email { get; set; }

        public string DiscordName { get; set; }

        public string PhoneOwner { get; set; }

        public string PhoneNumber { get; set; }
        public string SchoolName { get; set; }
        public EducationLevel EducationLevel { get; set; }
        public int EducationYear { get; set; }
    }
}
