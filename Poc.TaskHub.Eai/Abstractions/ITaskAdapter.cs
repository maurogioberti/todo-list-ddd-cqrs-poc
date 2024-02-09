using Poc.TaskHub.Business.Domain;

namespace Poc.TaskHub.Eai.Abstractions
{
    public interface ITaskAdapter
    {
        IEnumerable<TaskDataView> GetAll();
    }
}