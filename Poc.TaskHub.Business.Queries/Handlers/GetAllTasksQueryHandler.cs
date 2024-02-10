using Poc.TaskHub.Business.Dto;
using Poc.TaskHub.Business.Mappers.Abstractions;
using Poc.TaskHub.Business.Queries.Infrastructure.Abstractions;
using Poc.TaskHub.Eai.Abstractions;

namespace Poc.TaskHub.Business.Queries.Handlers
{
    public class GetAllTasksQueryHandler(ITaskAdapter taskAdapter, ITaskMapper taskMapper) : IQueryHandler<GetAllTasksQuery, IEnumerable<TaskDto>>
    {
        private readonly ITaskAdapter _taskAdapter = taskAdapter;
        private readonly ITaskMapper _taskMapper = taskMapper;

        public IEnumerable<TaskDto> Handle(GetAllTasksQuery query)
        {
            var taskDomains = _taskAdapter.GetAll();
            return taskDomains.Select(x => _taskMapper.Map(x));
        }
    }
}