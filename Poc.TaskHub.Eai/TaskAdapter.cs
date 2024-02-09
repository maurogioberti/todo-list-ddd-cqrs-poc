using AutoFixture;
using Poc.TaskHub.Business.Domain;
using Poc.TaskHub.Eai.Abstractions;

namespace Poc.TaskHub.Eai
{
    public class TaskAdapter : ITaskAdapter
    {
        // TODO: In a real scenario, this method would perform database operations to retrieve tasks.
        // Currently, it mocks data retrieval using AutoFixture for demonstration purposes in this POC.
        // Replace mock implementation with actual database interaction in production.

        private readonly Fixture fixture = new();

        public IEnumerable<TaskDataView> GetAll() => fixture.CreateMany<TaskDataView>();
    }
}