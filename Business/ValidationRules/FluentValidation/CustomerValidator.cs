using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.DependencyResolvers.ValidationRules.FluentValidation
{
    public class CustomerValidator:AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            //Kurallar
            RuleFor(c => c.UserId).NotEmpty().NotNull();
        }
    }
}
