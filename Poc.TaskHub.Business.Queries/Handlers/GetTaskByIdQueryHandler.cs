using Poc.TaskHub.Api.Business.Validation.Infrastructure;
using Poc.TaskHub.Business.Dto;
using Poc.TaskHub.Business.Mappers.Abstractions;
using Poc.TaskHub.Business.Queries.Infrastructure.Abstractions;
using Poc.TaskHub.Eai.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace Poc.TaskHub.Business.Queries.Handlers
{
    public class GetTaskByIdQueryHandler(ITaskAdapter taskDataAdapter, ITaskMapper taskMapper) : IQueryHandler<GetTaskByIdQuery, TaskDto>
    {
        private readonly ITaskAdapter _taskAdapter = taskDataAdapter;
        private readonly ITaskMapper _taskMapper = taskMapper;

        public TaskDto Handle(GetTaskByIdQuery query)
        {
            var validation = EntityDtoValidator.ValidateMandatory(query.ToDto(), nameof(query.Id));

            if (!validation.IsValid)
                throw new ValidationException(validation.Message);

            var taskDomain = _taskAdapter.Get(query.Id);

            if (taskDomain == null)
                return null;

            return _taskMapper.Map(taskDomain);
        }
    }
}