using TEROS.Domain.Interfaces;
using FluentValidation.Results;

namespace TEROS.Application.Validation;

public readonly record struct FluentValidationError : IValidationError
{
    public string Message { get; }

    public FluentValidationError(ValidationResult result)
    {
        Message = $"Erro no formulário: {string.Join("; ", result.Errors.Select(x => x.ErrorMessage))}";
    }

    public FluentValidationError(IEnumerable<ValidationFailure> errors)
    {
        Message = $"Erro no formulário: {string.Join("; ", errors.Select(x => x.ErrorMessage))}";
    }
}
