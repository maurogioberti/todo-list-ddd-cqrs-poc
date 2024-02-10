using AutoFixture;
using Poc.TaskHub.Eai.Abstractions;

namespace Poc.TaskHub.Eai
{
    /// <summary>
    /// Retrieves all tasks. Currently, this method uses AutoFixture to generate mock data for demonstration purposes.
    /// TODO: Replace mock implementation with actual data retrieval from a database or external service in a production scenario.
    /// </summary>
    /// <returns>A collection of TaskDataView instances.</returns>
    public class TaskAdapter : ITaskAdapter
    {
        private readonly Fixture _fixture = new();

        public Business.Domain.Task Get(int id) => _fixture.Build<Business.Domain.Task>().With(x => x.Id, id).Create();

        public IEnumerable<Business.Domain.Task> GetAll() => _fixture.CreateMany<Business.Domain.Task>();
    }
}