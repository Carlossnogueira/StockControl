using FluentValidation;
using StockControl.Communication.Request.Item;

namespace StockControl.Service.Validation
{
    public class UpdateItemValidator : AbstractValidator<UpdateItemDto>
    {
        public UpdateItemValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("O nome do item é obrigatório.")
                .MaximumLength(100).WithMessage("O nome do item deve ter no máximo 100 caracteres.")
                .When(x => x.Name != null);

            RuleFor(x => x.Quantity)
                .GreaterThanOrEqualTo(0).WithMessage("A quantidade não pode ser negativa.")
                .When(x => x.Quantity.HasValue);

            RuleFor(x => x.Price)
                .GreaterThanOrEqualTo(0).WithMessage("O preço não pode ser negativo.")
                .When(x => x.Price.HasValue);

            RuleFor(x => x.SalePrice)
                .GreaterThanOrEqualTo(0).WithMessage("O preço de venda não pode ser negativo.")
                .When(x => x.SalePrice.HasValue);

            RuleFor(x => x.SalePrice)
                .GreaterThanOrEqualTo(x => x.Price ?? 0)
                .WithMessage("O preço de venda deve ser maior ou igual ao preço de custo.")
                .When(x => x.SalePrice.HasValue && x.Price.HasValue);

            RuleFor(x => x.CategoryId)
                .NotEmpty().WithMessage("A categoria é obrigatória.");
        }
    }
}