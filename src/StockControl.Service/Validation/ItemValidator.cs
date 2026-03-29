using FluentValidation;
using StockControl.Communication.Request.Item;

namespace StockControl.Service.Validation
{
    public class ItemValidator : AbstractValidator<CreateItemDto>
    {
        public ItemValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("O nome do item é obrigatório.")
                .MaximumLength(100).WithMessage("O nome do item deve ter no máximo 100 caracteres.");

            RuleFor(x => x.CategoryId)
                .GreaterThan(0).WithMessage("Categoria inválida.");

            RuleFor(x => x.Quantity)
                .GreaterThanOrEqualTo(0).WithMessage("A quantidade não pode ser negativa.");

            RuleFor(x => x.Price)
                .GreaterThanOrEqualTo(0).WithMessage("O preço não pode ser negativo.");

            RuleFor(x => x.SalePrice)
                .GreaterThanOrEqualTo(0).WithMessage("O preço de venda não pode ser negativo.");

            RuleFor(x => x.SalePrice)
                .GreaterThanOrEqualTo(x => x.Price)
                .WithMessage("O preço de venda deve ser maior ou igual ao preço de custo.");
        }
    }
}