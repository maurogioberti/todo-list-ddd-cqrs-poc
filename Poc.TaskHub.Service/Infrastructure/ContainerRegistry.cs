using Lamar;
using Poc.TaskHub.Business.Commands.Infrastructure.Abstractions;
using Poc.TaskHub.Business.Queries.Infrastructure.Abstractions;
using Poc.TaskHub.Eai.Infrstructure;
using Poc.TaskHub.Eai.Infrstructure.Abstractions;

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
            // TODO: The following method call is commented out as an example of how to manually register types that do not conform to the auto-registration conventions.
            // Specifically, this line is an example of how to integrate WCF client dependency injection, which is not utilized in this solution but provided as a proof of concept.
            // Uncomment and modify this section according to your project's needs for non-conventional type registration.

            //RegisterNonConventionBasedTypes(); 
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
            For(typeof(IWcfClientManager<>)).Use(typeof(WcfClientManager<>));
        }
    }
}