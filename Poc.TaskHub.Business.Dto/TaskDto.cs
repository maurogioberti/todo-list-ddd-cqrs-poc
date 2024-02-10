
using Poc.TaskHub.Business.Domain.Infrastructure;

namespace Poc.TaskHub.Business.Dto
{
    public class TaskDto : EntityDto<int>
    {
        public string Content { get; set; } = string.Empty;
        public bool IsCompleted { get; set; }
    }
}