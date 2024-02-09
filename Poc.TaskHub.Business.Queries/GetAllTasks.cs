using Poc.TaskHub.Business.Domain;
using Poc.TaskHub.Business.Queries.Infrastructure.Abstractions;

namespace Poc.TaskHub.Business.Queries
{
    public class GetAllTasksQuery : IQuery<IEnumerable<TaskDataView>>
    {
    }
}