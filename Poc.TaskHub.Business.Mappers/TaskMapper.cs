using Poc.TaskHub.Business.Dto;
using Poc.TaskHub.Business.Mappers.Abstractions;

namespace Poc.TaskHub.Business.Mappers
{
    public class TaskMapper : ITaskMapper
    {
        public Domain.Task Map(TaskDto textSort) => new()
        {
            Id = textSort.Id,
            Description = textSort.Description,
            Content = textSort.Content,
            IsCompleted = textSort.IsCompleted
        };

        public TaskDto Map(Domain.Task textSort) => new()
        {
            Id = textSort.Id,
            Description = textSort.Description,
            Content = textSort.Content,
            IsCompleted = textSort.IsCompleted
        };
    }
}