namespace Poc.TaskHub.Api.Business.Validation.Infrastructure
{
    /// <summary>
    /// Represents the outcome of a validation check, including validity status and any associated message.
    /// </summary>
    /// <param name="isValid">Indicates whether the validation is successful.</param>
    /// <param name="message">The message associated with the validation result.</param>
    public record ValidateObject(bool IsValid, string Message);
}