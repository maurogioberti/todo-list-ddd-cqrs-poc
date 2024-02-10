using Poc.TaskHub.Api.Business.Validation.Infrastructure;
using Poc.TaskHub.Business.Commands.Infrastructure.Abstractions;
using Poc.TaskHub.Business.Dto;
using Poc.TaskHub.Business.Mappers.Abstractions;
using Poc.TaskHub.Eai.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace Poc.TaskHub.Business.Commands.Handlers
{
    public class CreateTaskCommandHandler(ITaskAdapter taskAdapter, ITaskMapper taskMapper) : ICommandHandler<CreateTaskCommand, TaskDto>
    {
        private readonly ITaskAdapter _taskAdapter = taskAdapter;
        private readonly ITaskMapper _taskMapper = taskMapper;

        public TaskDto Handle(CreateTaskCommand command)
        {
            var taskDto = command.ToDto();

            var validation = TaskDtoCreationValidator.Validate(taskDto);

            if (!validation.IsValid)
                throw new ValidationException(validation.Message);

            var result = _taskAdapter.Create(taskDto.Description, taskDto.Content, taskDto.IsCompleted);

            return _taskMapper.Map(result);
        }
    }
}