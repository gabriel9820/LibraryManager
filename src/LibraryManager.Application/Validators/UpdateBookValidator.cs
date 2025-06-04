using FluentValidation;
using LibraryManager.Application.Commands.UpdateBook;

namespace LibraryManager.Application.Validators;

public class UpdateBookValidator : AbstractValidator<UpdateBookCommand>
{
    public UpdateBookValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Título é obrigatório")
            .MaximumLength(200).WithMessage("Título deve ter no máximo {MaxLength} caracteres");

        RuleFor(x => x.Author)
            .NotEmpty().WithMessage("Autor é obrigatório")
            .MaximumLength(200).WithMessage("Autor deve ter no máximo {MaxLength} caracteres");

        RuleFor(x => x.ISBN)
            .NotEmpty().WithMessage("ISBN é obrigatório")
            .MaximumLength(13).WithMessage("ISBN deve ter no máximo {MaxLength} caracteres");

        RuleFor(x => x.PublicationYear)
            .NotEmpty().WithMessage("Ano de publicação é obrigatório");

        RuleFor(x => x.IsAvailable)
            .NotNull().WithMessage("Disponibilidade é obrigatória");
    }
}
