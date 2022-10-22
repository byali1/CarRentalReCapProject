using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.DependencyResolvers.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            //Kurallar
            RuleFor(u => u.FirstName).NotEmpty().NotNull();
            RuleFor(u => u.FirstName).MinimumLength(2);

            RuleFor(u => u.LastName).NotEmpty().NotNull();
            RuleFor(u => u.LastName).MinimumLength(2);

            RuleFor(u => u.Email).NotEmpty().NotNull();
            RuleFor(u => u.Email).EmailAddress();

            RuleFor(u => u.Password).NotEmpty().NotNull();
            RuleFor(u => u.Password).MinimumLength(8);



        }
    }
}
