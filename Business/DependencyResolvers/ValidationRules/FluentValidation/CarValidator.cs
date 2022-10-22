using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.DependencyResolvers.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            //kurallar
            RuleFor(c => c.BrandId).NotEmpty().NotNull();

            RuleFor(c => c.ColorId).NotEmpty().NotNull();

            RuleFor(c => c.ModelYear).NotEmpty().NotNull();

            RuleFor(c => c.DailyPrice).NotEmpty().NotNull();
            RuleFor(c => c.DailyPrice).GreaterThan(0);

            RuleFor(c => c.Description).NotEmpty().NotNull();
            RuleFor(c => c.Description).MinimumLength(2);
        }

    }
}
