using Poc.TaskHub.Business.Commands.Infrastructure.Abstractions;
using Poc.TaskHub.Business.Dto;

namespace Poc.TaskHub.Business.Commands
{
    public class CreateTaskCommand : ICommand<TaskDto>
    {
        public string Description { get; set; }
        public string Content { get; set; }
        public bool IsCompleted { get; set; }

        public TaskDto ToDto()
        {
            return new TaskDto() { Description = Description, Content = Content, IsCompleted = IsCompleted };
        }
    }
}