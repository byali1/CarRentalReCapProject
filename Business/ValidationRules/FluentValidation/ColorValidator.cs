using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.DependencyResolvers.ValidationRules.FluentValidation
{
    public class ColorValidator : AbstractValidator<Color>
    {
        public ColorValidator()
        {
            //Kurallar
            RuleFor(c => c.Name).NotEmpty().NotNull();
            RuleFor(c => c.Name).MinimumLength(2);
        }
    }
}
