using FluentValidation;
using LibraryManager.Application.Commands.CreateUser;

namespace LibraryManager.Application.Validators;

public class CreateUserValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Nome é obrigatório")
            .MaximumLength(200).WithMessage("Nome deve ter no máximo {MaxLength} caracteres");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email é obrigatório")
            .EmailAddress().WithMessage("Email inválido")
            .MaximumLength(200).WithMessage("Email deve ter no máximo {MaxLength} caracteres");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Senha é obrigatória")
            .MinimumLength(8).WithMessage("Senha deve ter pelo menos {MinLength} caracteres")
            .MaximumLength(100).WithMessage("Senha deve ter no máximo {MaxLength} caracteres");

        RuleFor(x => x.Role)
            .NotEmpty().WithMessage("Cargo é obrigatório")
            .Must(role => role == "Admin" || role == "User").WithMessage("Cargo inválido");
    }
}
