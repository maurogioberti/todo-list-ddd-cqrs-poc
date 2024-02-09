
using Poc.TaskHub.Business.Domain.Infrastructure;

namespace Poc.TaskHub.Business.Domain
{
    public class TaskDataView : DataView<int>
    {
        public string Content { get; set; } = string.Empty;
        public bool IsCompleted { get; set; }
    }
}