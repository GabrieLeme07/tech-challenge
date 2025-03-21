using Ambev.DeveloperEvaluation.Domain.Repositories;
using FluentValidation.Results;

namespace Ambev.DeveloperEvaluation.Application.Common;

public abstract class CommandHandler
{

    /// <summary>
    /// Validation Result
    /// </summary>
    protected ValidationResult ValidationResult;

    protected CommandHandler()
        => ValidationResult = new();

    /// <summary>
    /// Comimit Data
    /// </summary>
    /// <param name="uow">Unit of Work</param>
    protected async Task<ValidationResult> Commit(IUnitOfWork uow)
        => await Commit(uow, "There was an error saving data").ConfigureAwait(false);

    /// <summary>
    /// Commit Data
    /// </summary>
    /// <param name="uow">Unit of Work</param>
    /// <param name="message">Error Message if not success</param>
    /// <returns></returns>
    protected async Task<ValidationResult> Commit(IUnitOfWork uow, string message)
    {
        if (!await uow.Commit())
            AddError(0xC0001, message);

        return ValidationResult;
    }

    /// <summary>
    /// Insert Validation Failure on ValidationResult object
    /// </summary>
    /// <param name="message">Validation Error Message</param>
    protected ValidationResult AddError(int errorCode, string message)
    {
        ValidationResult.Errors.Add(new ValidationFailure(string.Empty, message)
        {
            ErrorCode = errorCode.ToString("X")
        });
        return ValidationResult;
    }

}
