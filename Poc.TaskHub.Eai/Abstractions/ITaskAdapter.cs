namespace Poc.TaskHub.Eai.Abstractions
{
    public interface ITaskAdapter
    {
        IEnumerable<Business.Domain.Task> GetAll();
        Business.Domain.Task Get(int id);
    }
}