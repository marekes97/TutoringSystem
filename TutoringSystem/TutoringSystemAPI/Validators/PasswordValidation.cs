using FluentValidation;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutoringSystemLib.Entities;
using TutoringSystemLib.Models;

namespace TutoringSystemAPI.Validators
{
    public class PasswordValidation : AbstractValidator<PasswordDto>
    {
        public PasswordValidation()
        {
            RuleFor(p => p.NewPassword).MinimumLength(4);
            RuleFor(p => p.NewPassword).Equal(p => p.ConfirmPassword);
        }
    }
}
