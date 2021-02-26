using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutoringSystemLib.Models;

namespace TutoringSystemAPI.Validators
{
    public class RegisterUserValidation : AbstractValidator<RegisterUserDto>
    {
        public RegisterUserValidation(AppDbContext dbContext)
        {
            RuleFor(u => u.UserName).NotEmpty();
            RuleFor(u => u.UserName).Custom((value, context) =>
            {
                var loginAlreadyExist = dbContext.Users.Any(user => user.UserName == value);
                if (loginAlreadyExist)
                    context.AddFailure("userName", "That user name is taken");
            });

            RuleFor(u => u.Password).MinimumLength(4);
            RuleFor(u => u.Password).Equal(u => u.ConfirmPassword);

            RuleFor(u => u.FirstName).NotEmpty();
        }
    }
}
