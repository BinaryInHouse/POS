using System;
using FluentValidation;
using POS.Application.Dtos.Request;

namespace POS.Application.Validators.Category
{
	public class CategoryValidator : AbstractValidator<CategoryRequestDto>
	{
		public CategoryValidator()
		{
			RuleFor(x => x.Name)
				.NotNull().WithMessage("El campo nombre no puede ser nulo.")
				.NotEmpty().WithName("El campo nombre no puede ser vacio.");
		}
	}
}

