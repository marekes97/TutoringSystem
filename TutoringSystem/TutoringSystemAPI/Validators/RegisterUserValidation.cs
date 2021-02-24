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
            RuleFor(u => u.Login).NotEmpty();
            RuleFor(u => u.Login).Custom((value, context) =>
            {
                var loginAlreadyExist = dbContext.Users.Any(user => user.Login == value);
                if (loginAlreadyExist)
                    context.AddFailure("Login", "That login is taken");
            });

            RuleFor(u => u.Password).MinimumLength(4);
            RuleFor(u => u.Password).Equal(u => u.ConfirmPassword);

            RuleFor(u => u.FirstName).NotEmpty();
        }
    }
}
