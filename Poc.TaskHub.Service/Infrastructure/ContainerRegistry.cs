using Lamar;
using Poc.TaskHub.Business.Commands.Infrastructure.Abstractions;
using Poc.TaskHub.Business.Queries.Infrastructure.Abstractions;
using Poc.TaskHub.Eai.Infrstructure;
using Poc.TaskHub.Service.Infrastructure.Abstractions;

namespace Poc.TaskHub.Api.Service.Infrastructure
{
    /// <summary>
    /// Configures service registration and auto-registration conventions within the IoC container.
    /// </summary>
    public class ContainerRegistry : ServiceRegistry
    {
        private const string AssemblyName = "Poc.TaskHub";

        /// <summary>
        /// Initializes a new instance of the <see cref="ContainerRegistry"/> class, setting up auto-registration and explicit registration.
        /// </summary>
        public ContainerRegistry()
        {
            AutoRegisterConventionBasedTypes();
            RegisterNonConventionBasedTypes();
        }

        /// <summary>
        /// Registers types based on scanning conventions.
        /// </summary>
        private void AutoRegisterConventionBasedTypes()
        {
            Scan(scanner =>
            {
                scanner.AssembliesFromApplicationBaseDirectory(assembly => assembly.FullName.StartsWith(AssemblyName));
                scanner.ConnectImplementationsToTypesClosing(typeof(ICommandHandler<,>));
                scanner.ConnectImplementationsToTypesClosing(typeof(IQueryHandler<,>));
                scanner.Exclude(type => type.IsAssignableFrom(typeof(WcfClientManager<>)));
                scanner.WithDefaultConventions();
            });
        }

        /// <summary>
        /// Registers types that do not follow the auto-registration conventions.
        /// </summary>
        private void RegisterNonConventionBasedTypes()
        {
            For<IQueryProcessor>().Use<QueryProcessor>();

            // TODO: This commented line is a guide for registering types not following auto-registration conventions.
            // Example shown for integrating WCF client dependency injection, not utilized in this POC.
            // Uncomment and adjust for non-conventional type registration as needed.
            // For(typeof(IWcfClientManager<>)).Use(typeof(WcfClientManager<>));
        }
    }
}