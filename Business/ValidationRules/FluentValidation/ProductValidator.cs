using System;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
	public class ProductValidator : AbstractValidator<Product>
	{
		public ProductValidator()
		{
			RuleFor(q => q.product_name).MinimumLength(2);
			RuleFor(q => q.product_name).NotEmpty();
			RuleFor(q => q.unit_price).NotEmpty();
			RuleFor(q => q.unit_price).GreaterThan(0);
			RuleFor(q => q.unit_price).GreaterThanOrEqualTo(10).When(q => q.category_id == 1);
			RuleFor(q => q.product_name).Must(StartWithA)
				.WithMessage("Ürünler A harfi ile başlamalıdır");
		}

        private bool StartWithA(string arg)
        {
			return arg.StartsWith("A");
        }
    }
}

