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
        public ActionResult<IEnumerable<TaskDto>> GetAllTasks()
        {
            var query = new GetAllTasksQuery();
            var result = _queryProcessor.Process(query);

            if (result == null || !result.Any())
                return NotFound(NoTasksFound);

            return Ok(result);
        }
    }
}