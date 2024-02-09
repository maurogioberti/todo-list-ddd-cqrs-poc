using Poc.TaskHub.Business.Domain;
using Poc.TaskHub.Business.Queries.Infrastructure.Abstractions;
using Poc.TaskHub.Eai.Abstractions;

namespace Poc.TaskHub.Business.Queries.Infrastructure
{
    public class GetAllTasksQueryHandler(ITaskAdapter taskAdapter) : IQueryHandler<GetAllTasksQuery, IEnumerable<TaskDataView>>
    {
        private readonly ITaskAdapter _taskAdapter = taskAdapter;

        public IEnumerable<TaskDataView> Handle(GetAllTasksQuery query)
        {
            return _taskAdapter.GetAll();
        }
    }
}