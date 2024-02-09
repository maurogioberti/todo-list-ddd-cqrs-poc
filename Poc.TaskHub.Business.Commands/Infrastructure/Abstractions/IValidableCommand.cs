namespace Poc.TaskHub.Business.Commands.Infrastructure.Abstractions
{
    /// <summary>
    /// Defines a command that can be validated.
    /// </summary>
    public interface IValidableCommand
    {
        /// <summary>
        /// Gets the validation message.
        /// </summary>
        /// <returns>The validation message.</returns>
        string Message();

        /// <summary>
        /// Assigns a validation message.
        /// </summary>
        /// <param name="message">The validation message to assign.</param>
        void AssignMessage(string message);

        /// <summary>
        /// Checks if the command is valid.
        /// </summary>
        /// <returns>True if the command is valid; otherwise, false.</returns>
        bool IsValid();
    }
}