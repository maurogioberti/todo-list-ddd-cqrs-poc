using Microsoft.AspNetCore.Mvc;
using Poc.TaskHub.Business.Commands;
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
        private readonly ICommandProcessor _commandProcessor;

        private const string ContentType = "application/json";

        private const string NoTasksFound = "No tasks found.";
        private const string TaskIdNotFound = "Task with ID {0} not found.";
        private const string UnableToCreateTask = "Unable to create task.";

        public TasksController(IQueryProcessor queryProcessor, ICommandProcessor commandProcessor)
        {
            Argument.ThrowIfNull(() => queryProcessor);
            Argument.ThrowIfNull(() => commandProcessor);

            _queryProcessor = queryProcessor;
            _commandProcessor = commandProcessor;
        }

        [HttpGet]
        [Produces(ContentType)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<TaskDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TaskDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<TaskDto> GetById(int id)
        {
            var query = new GetTaskByIdQuery(id);
            var task = _queryProcessor.Process(query);

            if (task == null)
                return NotFound(string.Format(TaskIdNotFound, id));

            return Ok(task);
        }

        [HttpPost]
        [Produces(ContentType)]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(TaskDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<TaskDto> Create([FromBody] CreateTaskCommand command)
        {
            var createdTask = _commandProcessor.Process(command);

            if (createdTask == null || createdTask.Id <= 0)
                return BadRequest(UnableToCreateTask);

            var resourceLocation = Url.Action(nameof(Create), new { id = createdTask.Id });
            return Created(resourceLocation, createdTask);
        }
    }
}