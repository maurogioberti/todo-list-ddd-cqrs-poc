using Poc.TaskHub.Business.Dto;

namespace Poc.TaskHub.Business.Mappers.Abstractions
{
    public interface ITaskMapper
    {
        TaskDto Map(Domain.Task textSort);
        Domain.Task Map(TaskDto textSort);
    }
}