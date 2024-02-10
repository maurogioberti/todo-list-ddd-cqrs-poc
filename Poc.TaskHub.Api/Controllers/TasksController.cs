using Microsoft.AspNetCore.Mvc;
using Poc.TaskHub.Business.Dto;
using Poc.TaskHub.Business.Queries;
using Poc.TaskHub.CrossCutting.Exceptions;
using Poc.TaskHub.Service.Infrastructure.Abstractions;

namespace Poc.TaskHub.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly IQueryProcessor _queryProcessor;

        private const string NoTasksFound = "No tasks found.";
        private const string ContentType = "application/json";
        private const string TaskIdNotFound = "Task with ID {0} not found.";

        public TasksController(IQueryProcessor queryProcessor)
        {
            Argument.ThrowIfNull(() => queryProcessor);
            _queryProcessor = queryProcessor;
        }

        [HttpGet]
        [Produces(ContentType)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<TaskDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<TaskDto>> GetAll()
        {
            var query = new GetAllTasksQuery();
            var result = _queryProcessor.Process(query);

            if (result == null || !result.Any())
                return NotFound(NoTasksFound);

            return Ok(result);
        }

        [HttpGet("{id}")]
        [Produces(ContentType)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<TaskDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<TaskDto> GetById(int id)
        {
            var query = new GetTaskByIdQuery(id);
            var task = _queryProcessor.Process(query);

            if (task == null)
                return NotFound(string.Format(TaskIdNotFound, id));

            return Ok(task);
        }
    }
}