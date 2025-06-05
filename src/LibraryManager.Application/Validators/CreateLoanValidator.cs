using FluentValidation;
using LibraryManager.Application.Commands.CreateLoan;

namespace LibraryManager.Application.Validators;

public class CreateLoanValidator : AbstractValidator<CreateLoanCommand>
{
    public CreateLoanValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("ID do usuário é obrigatório");

        RuleFor(x => x.BookId)
            .NotEmpty().WithMessage("ID do livro é obrigatório");

        RuleFor(x => x.ExpectedReturnDate)
            .GreaterThan(DateTime.UtcNow).WithMessage("Data de devolução esperada deve ser uma data futura");
    }
}
