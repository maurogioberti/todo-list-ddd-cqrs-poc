namespace Poc.TaskHub.Business.Commands.Infrastructure.Abstractions
{
    /// <summary>
    /// Defines a handler for processing a command and producing a result.
    /// </summary>
    public interface ICommandHandler<TCommand, out TResult> where TCommand : ICommand<TResult>
    {
        /// <summary>
        /// Handles the specified command and returns the result.
        /// </summary>
        /// <param name="command">The command to handle.</param>
        /// <returns>The result produced by handling the command.</returns>
        TResult Handle(TCommand command);
    }
}