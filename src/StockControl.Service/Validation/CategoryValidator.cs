using System;
using FluentValidation;
using StockControl.Communication.Request.Catogory;

namespace StockControl.Service.Validation;

public class CategoryValidator : AbstractValidator<CreateCategoryDto>
{
    public CategoryValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("O nome da categoria é obrigatório.")
            .MaximumLength(50).WithMessage("O nome da categoria não pode exceder 50 caracteres.");
    }
}
