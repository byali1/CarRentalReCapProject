using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.DependencyResolvers.ValidationRules.FluentValidation
{
    public class RentalValidator : AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            //Kurallar
            RuleFor(r => r.CarId).NotEmpty().NotNull();
            RuleFor(r => r.CustomerId).NotEmpty().NotNull();
            RuleFor(r => r.RentDate).NotEmpty().NotNull();

           
        }
    }
}
