using Lamar;
using Poc.TaskHub.Business.Commands.Infrastructure.Abstractions;
using Poc.TaskHub.CrossCutting.Exceptions;
using Poc.TaskHub.Service.Infrastructure.Abstractions;

namespace Poc.TaskHub.Api.Service.Infrastructure
{
    /// <summary>
    /// Processes commands by finding the appropriate command handler using dependency injection.
    /// </summary>
    public sealed class CommandProcessor : ICommandProcessor
    {
        /// <summary>
        /// The IoC container used for resolving command handlers.
        /// </summary>
        private readonly IContainer _container;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandProcessor"/> class.
        /// </summary>
        /// <param name="container">The IoC container for resolving dependencies.</param>
        public CommandProcessor(IContainer container)
        {
            Argument.ThrowIfNull(() => container);
            _container = container;
        }

        /// <summary>
        /// Processes the specified command by finding and invoking the appropriate command handler.
        /// </summary>
        /// <typeparam name="TResult">The type of result expected from processing the command.</typeparam>
        /// <param name="command">The command to process.</param>
        /// <returns>The result produced by the command handler.</returns>
        public TResult Process<TResult>(ICommand<TResult> command)
        {
            Argument.ThrowIfNull(() => command);
            var handlerType = typeof(ICommandHandler<,>).MakeGenericType(command.GetType(), typeof(TResult));
            dynamic handler = _container.GetInstance(handlerType);
            return handler.Handle(command);
        }
    }
}