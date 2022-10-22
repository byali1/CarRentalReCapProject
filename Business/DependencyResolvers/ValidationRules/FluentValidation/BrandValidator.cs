
using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.DependencyResolvers.ValidationRules.FluentValidation
{
    public class BrandValidator : AbstractValidator<Brand>
    {
        public BrandValidator()
        {
            //Kurallar
            RuleFor(b => b.Name).NotEmpty().NotNull();
            RuleFor(b => b.Name).MinimumLength(2);
            
        }
    }
}
