using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace BasicProductSimulation.Validation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.Name).NotNull().NotEmpty();
            RuleFor(p => p.Price).NotNull().NotEmpty();
            RuleFor(p => p.Quantity).NotNull().NotEmpty();
        }
    }
}
