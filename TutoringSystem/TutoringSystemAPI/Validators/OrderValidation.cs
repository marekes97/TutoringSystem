using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutoringSystemLib.Models;

namespace TutoringSystemAPI.Validators
{
    public class OrderValidation : AbstractValidator<OrderDetailsDto>
    {
        public OrderValidation()
        {
            RuleFor(o => o.Name).NotEmpty();
            RuleFor(o => o.Cost).GreaterThan(0);
            RuleFor(o => o.Deadline).NotEmpty();
        }
    }
}
