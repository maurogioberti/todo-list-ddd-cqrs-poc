using AutoFixture;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using Poc.TaskHub.Api.Controllers;
using Poc.TaskHub.Business.Dto;
using Poc.TaskHub.Business.Queries;
using Poc.TaskHub.Service.Infrastructure.Abstractions;

namespace Poc.TaskHub.Api.Tests.Controllers
{
    [TestFixture]
    public class TasksControllerTests
    {
        private class TasksControllerBuilder
        {
            private Mock<IQueryProcessor> _queryProcessorMock;
            public Mock<IQueryProcessor> QueryProcessorMock => _queryProcessorMock ??= new Mock<IQueryProcessor>();


            public TasksController Build()
            {
                return new TasksController(_queryProcessorMock.Object);
            }
        }

        private readonly Fixture _fixture = new();

        [Test]
        public void GetAll_No_Tasks_Found_Should_Return_NotFound()
        {
            // Arrange
            var builder = new TasksControllerBuilder();
            builder.QueryProcessorMock.Setup(q => q.Process(It.IsAny<GetAllTasksQuery>())).Returns((IEnumerable<TaskDto>)null);

            // Act
            var controller = builder.Build();
            var result = controller.GetAll();

            // Assert
            Assert.That(result.Result, Is.InstanceOf<NotFoundObjectResult>());
        }

        [Test]
        public void GetAll_Tasks_Found_Should_Return_Ok()
        {
            // Arrange
            var tasks = _fixture.CreateMany<TaskDto>();
            var builder = new TasksControllerBuilder();
            builder.QueryProcessorMock.Setup(q => q.Process(It.IsAny<GetAllTasksQuery>())).Returns(tasks);

            // Act
            var controller = builder.Build();
            var result = controller.GetAll();

            // Assert
            var okResult = result.Result as OkObjectResult;
            var returnedTasks = okResult.Value as IEnumerable<TaskDto>;

            Assert.That(okResult, Is.Not.Null);
            Assert.That(tasks.Count(), Is.EqualTo(returnedTasks.Count()));
        }
    }
}