using Poc.TaskHub.Business.Commands.Infrastructure.Abstractions;

namespace Poc.TaskHub.Service.Infrastructure.Abstractions
{
    /// <summary>
    /// Defines the interface for processing commands.
    /// </summary>
    public interface ICommandProcessor
    {
        /// <summary>
        /// Processes the specified command and returns a result.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="command">The command to process.</param>
        /// <returns>The result of processing the command.</returns>
        TResult Process<TResult>(ICommand<TResult> command);
    }
}