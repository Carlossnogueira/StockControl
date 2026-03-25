using FluentValidation;
using StockControl.Communication.Request.User;

namespace StockControl.Service.Validation
{
    internal class UserValidator : AbstractValidator<CreateUserDto>
    {
        public UserValidator()
        {
            RuleFor(u => u.Name)
                .NotEmpty().WithMessage("Nome é obrigatório")
                .MinimumLength(3).WithMessage("Nome deve conter no minímo 3 caracteres.")
                .MaximumLength(50).WithMessage("Nome pode ter no maximo 50 caracteres.");

            RuleFor(u => u.Login)
                .NotEmpty().WithMessage("Login é obrigatório")
                .MinimumLength(5).WithMessage("Login deve conter no minímo 5 caracteres.")
                .MaximumLength(12).WithMessage("Login pode ter no maximo 12 caracteres.");
 
            RuleFor(u => u.Password)
                .NotEmpty().WithMessage("A senha é obrigatória")
                .MinimumLength(8).WithMessage("A senha deve conter no minímo 8 caracteres")
                .MaximumLength(12).WithMessage("A senha pode ter no maximo 12 caracteres.");
        }
    }
}
