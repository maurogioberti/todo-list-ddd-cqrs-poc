using Poc.TaskHub.Business.Dto;
using Poc.TaskHub.Business.Queries.Infrastructure.Abstractions;

namespace Poc.TaskHub.Business.Queries
{
    public class GetTaskByIdQuery(int id) : IQuery<TaskDto>
    {
        public int Id { get; set; } = id;

        public TaskDto ToDto()
        {
            return new TaskDto() { Id = Id };
        }
    }
}